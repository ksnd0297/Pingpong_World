using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBallMovement : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float speedZ;

    public Vector3 ballPosition;
    public Quaternion ballRotation;

    private Rigidbody yellowBall;
    private Rigidbody yellowBallInstance;
    private Vector3 movement;

    GameObject instance;

    void Start()
    {
        yellowBall = GetComponent<Rigidbody>();
        movement = new Vector3(this.speedX, this.speedY, this.speedZ);
        ballRotation = yellowBall.rotation;
        ballPosition = yellowBall.position;
    }

    private void Update()
    {
        if (this.gameObject.transform.position.x >= 4) Destroy(this.gameObject);
    }

    public void createBall()
    {
        instance = (GameObject)Instantiate(this.gameObject, ballPosition, ballRotation);
        yellowBallInstance = instance.GetComponent<Rigidbody>();
        yellowBallInstance.AddForce(movement);
        yellowBallInstance.GetComponent<Renderer>().enabled = true;
    }
}
