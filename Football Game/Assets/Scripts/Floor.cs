using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple collider trigger for when the ball lands back on/near the ground level. 
/// If it is the ball and the ball is active (not being reset), tell the GameManager to increment the level. 
/// </summary>
public class Floor : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball" && gameManager.activeBall)
        {
            gameManager.IncrementLevel();
        }
    }
}
