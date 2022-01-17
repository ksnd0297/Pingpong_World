using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBallAppearLocation : MonoBehaviour
{
    YellowBallMovement yellowBall;
    // Start is called before the first frame update
    void Start()
    {
        yellowBall = FindObjectOfType<YellowBallMovement>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note2"))
        {
            yellowBall.createBall();
        }
    }
}
