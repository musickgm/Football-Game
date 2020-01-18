using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the input (spacebar) from the player to kick the ball with the direction
/// and thrust provided by the aiming object's position. Only works if the ball isn't
/// already active. 
/// </summary>
public class Kicker : MonoBehaviour
{
    public Football football;
    public AimingObject aimingObject;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gameManager.activeBall)
        {
            float _thrust = aimingObject.transform.localPosition.z / 3;
            Vector3 _direction = aimingObject.transform.position - transform.position;
            football.AddImpulse(_direction, _thrust);
        }
    }
}
