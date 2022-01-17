using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallMovement : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float speedZ;

    public Vector3 ballPosition;
    public Quaternion ballRotation;

    private Rigidbody whiteBall;
    private Rigidbody whiteBallInstance;
    private Vector3 movement;

    GameObject instance;

    void Start()
    {
        whiteBall = GetComponent<Rigidbody>();
        movement = new Vector3(this.speedX, this.speedY, this.speedZ);
        ballRotation = whiteBall.rotation;
        ballPosition = whiteBall.position;
    }

    private void Update()
    {
        if (this.gameObject.transform.position.x >= 4) Destroy(this.gameObject);
    }

    public void createBall()
    {
        instance = (GameObject)Instantiate(this.gameObject, ballPosition, ballRotation);
        whiteBallInstance = instance.GetComponent<Rigidbody>();
        whiteBallInstance.AddForce(movement);
        whiteBallInstance.GetComponent<Renderer>().enabled = true;
    }
}
