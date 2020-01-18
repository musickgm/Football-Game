using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AimingObject is a script to allow player controls for moving the object used to aim the kick.
/// </summary>
public class AimingObject : MonoBehaviour
{
    public float speedFactor = 3;

    private Vector3 moveDirection;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Awake()
    {
        initialPosition = transform.localPosition;
    }

    /// <summary>
    /// Update is called once per frame. Check for user input.
    /// AWDS or arrows control horizontal and vertical movement of the ball.
    /// Shift/Control are used to control the depth (z) and thus the thrust. 
    /// </summary>
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speedFactor;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * speedFactor;
        float z = 0;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            z = 1 * Time.deltaTime * (speedFactor/2);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
           z = -1 * Time.deltaTime * (speedFactor/2);
        }
        moveDirection = new Vector3(x, y, z);

        transform.Translate(moveDirection);
        Clamp();
    }


    /// <summary>
    /// When the ball is reset, GameManager also resets the aiming object. 
    /// </summary>
    public void ResetAimingObject()
    {
        transform.localPosition = initialPosition;
    }

    /// <summary>
    /// Ensure the player input has reasonable values for the object position. 
    /// </summary>
    private void Clamp()
    {
        float x = Mathf.Clamp(transform.localPosition.x, -7, 7);
        float y = Mathf.Clamp(transform.localPosition.y, 1, 7);
        float z = Mathf.Clamp(transform.localPosition.z, 3, 5);

        transform.localPosition = new Vector3(x, y, z);
    }
}
