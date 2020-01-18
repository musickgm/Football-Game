using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles game progression (incrementation of levels, score, etc).
/// </summary>
public class GameManager : MonoBehaviour
{
    public List<Vector3> levelPositions;                    //List of positions the ball should be placed at for each level
    public Transform kickingPosition;                       //The parent "KickingPosition" object that holds the ball, aimer, camera, etc.
    public Football football;                               
    public AimingObject aimingObject;
    public Text scoreText;
    public Text levelText;
    public Text gameOverText;
    public bool activeBall = false;

    private int score = 0;
    private int levelNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = -1;
        IncrementLevel();
    }

    /// <summary>
    /// Quit the game when the player presses "Q"
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Called by the field goal collider if a goal is scored - increments score and text. 
    /// </summary>
    public void IncrementScore()
    {
        score += 3;
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Once the ball hits the ground (Floor collider), we increment the level, ball position, reset everything.
    /// If we are out of levels, return and display the game over text. 
    /// </summary>
    public void IncrementLevel()
    {
        levelNumber++;
        if(levelNumber >= levelPositions.Count)
        {
            GameOver();
            return;
        }
        kickingPosition.position = levelPositions[levelNumber];
        activeBall = false;
        football.ResetBall();
        aimingObject.ResetAimingObject();
        UpdateText();
    }

    /// <summary>
    /// Update the score and level text when we start a new level. 
    /// </summary>
    private void UpdateText()
    {
        scoreText.text = score.ToString();
        levelText.text = (levelNumber + 1).ToString() + "/" + levelPositions.Count.ToString();
    }

    /// <summary>
    /// Once we're out of levels, turn off some objects and display the game over text + the score
    /// </summary>
    private void GameOver()
    {
        football.gameObject.SetActive(false);
        aimingObject.gameObject.SetActive(false);
        gameOverText.text = "GAME OVER \n SCORE = " + score;
        gameOverText.enabled = true;
    }
}
