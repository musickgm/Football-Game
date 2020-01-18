using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Football script to handle adding impulse to the ball (when kicked)
/// and resetting when time for the next level. 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Football : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody footballRB;
    private readonly float torque = 50;
    // Start is called before the first frame update
    void Awake()
    {
        footballRB = GetComponent<Rigidbody>();
    }



    /// <summary>
    /// Function called by the Kicker script to add impulse to the ball. 
    /// Tells the GameManager that it is an active ball. 
    /// Also provide a torque just for fun. 
    /// </summary>
    /// <param name="direction"></param> the direction of the aiming object
    /// <param name="thrust"></param> the depth (modified) of the aiming object. 
    public void AddImpulse(Vector3 direction, float thrust)
    {
        footballRB.isKinematic = false;
        footballRB.AddForce(direction * thrust, ForceMode.Impulse);
        footballRB.AddTorque(transform.right * torque);
        gameManager.activeBall = true;
    }

    /// <summary>
    /// When a new level starts, reset the ball (no velocity, etc.)
    /// </summary>
    public void ResetBall()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        footballRB.velocity = new Vector3(0, 0, 0);
        footballRB.isKinematic = true;
    }
}
