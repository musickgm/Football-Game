using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple collider trigger for when the ball goes through the uprights. 
/// When the ball enters (and it is a ball) - tell the GameManager to increment the score. 
/// </summary>
public class FieldGoal : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            gameManager.IncrementScore();
        }
    }
}
