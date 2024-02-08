using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Functions with blue names are Unity functions

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    //Difference between positions from current frame and next frame
    private Vector3 moveDelta;

    //Function called on start
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //Function that is called on every frame
    private void FixedUpdate()
    {
        //returns -1(Left/Up), 0(no key), 1(Right/Down)
        //Can check in Edit - Project Settings - Input Manager
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        //like console.log()
        /*Debug.Log(x);
        Debug.Log(y);*/

        //Swap sprite direction whether you're going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Make player move (* Time.deltaTime makes movement equal on slower and faster devices)
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
