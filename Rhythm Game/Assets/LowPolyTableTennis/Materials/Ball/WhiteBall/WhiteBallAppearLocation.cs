using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallAppearLocation : MonoBehaviour
{
    WhiteBallMovement whiteBall;

    // Start is called before the first frame update
    void Start()
    {
        whiteBall = FindObjectOfType<WhiteBallMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note1"))
        {
            whiteBall.createBall();
        }
    }
}
