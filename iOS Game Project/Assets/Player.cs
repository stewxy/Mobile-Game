using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
}
