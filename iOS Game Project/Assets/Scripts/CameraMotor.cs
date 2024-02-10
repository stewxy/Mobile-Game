using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This camera moves when the player is out of boundX and boundY values
public class CameraMotor : MonoBehaviour
{
    //Focus on player
    public Transform lookAt;
    //Designated how far the player can go in x before the camera starts following
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    //LateUpdate is called after Update and FixedUpdate, camera moves after the player moves for better sync
    private void LateUpdate()
    {
        //Variable to calculate difference between current and next frame
        Vector3 delta = new Vector3(0,0,0);

        //Check if we're in the bounds on the x axis, lookAt.position.x represents players locatino, transorm.position.x represents the middle of cameras focus
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            //Player is on the right, focus of camera is on the left
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            //Player is on the left, focus of camera is on the right
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //Check if we're in the bounds on the y axis, lookAt.position.y represents players locatino, transorm.position.y represents the middle of cameras focus
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            //Player is up, focus of camera is down
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            //Player is down, focus of camera is up
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        //Move the camera
        transform.position += new Vector3(delta.x, delta.y, 0);

    }
}
