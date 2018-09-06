using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{

    public GameObject left;
    public GameObject right;

    public GameObject body;

    public Rigidbody bodyRb;
    public Rigidbody leftRb;
    public Rigidbody rightRb;

    private float forwardSpeed = 1f;
    private float yaw = 20;
    private float pitch = 1000;
    private float accelResetRate = 0.1f;
    private float rotationResetRate = 0.002f;

    private Vector3 vertAccel;
    private Vector3 horiAccel;
    private Vector3 vertAccelChangeRate = 1.5f * Vector3.up;
    private Vector3 horiAccelChangeRate = 0.2f * Vector3.forward; // Forward was Z
    private Vector3 forwardMovement;

    private void Start()
    {

        left = GameObject.Find("Left");
        right = GameObject.Find("Right");
        body = GameObject.Find("Body");

        //camera = body.GetComponent<Camera>();

        bodyRb = body.GetComponent<Rigidbody>();
        leftRb = left.GetComponent<Rigidbody>();
        rightRb = right.GetComponent<Rigidbody>();

        Physics.gravity = 2f * Vector3.down;

        forwardMovement = forwardSpeed * Vector3.right;
    }

    private void Update()
    {

        body.transform.Translate(forwardMovement * Time.deltaTime);

		if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			&& (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
			// press Left and Right at the same time
			LiftUp();

		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            // Left
            LiftLeft();

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            // Right
            LiftRight();

        UpdateRotation();
        UpdatePlayerVelocity();
        UpdateAccels();
    }

	private void LiftUp()
	{
		vertAccel = vertAccel + vertAccelChangeRate / 2;
		body.transform.Rotate(Vector3.up, yaw * Time.deltaTime);
	}

    private void LiftLeft()
    {
        vertAccel = vertAccel + vertAccelChangeRate;
        horiAccel = horiAccel + horiAccelChangeRate;
        body.transform.Rotate(Vector3.up, yaw * Time.deltaTime);
        body.transform.Rotate(Vector3.right, pitch * Time.deltaTime);
        Camera.main.transform.Rotate(Vector3.forward, -pitch * Time.deltaTime);
    }

    private void LiftRight()
    {
        vertAccel = vertAccel + vertAccelChangeRate;
        horiAccel = horiAccel - horiAccelChangeRate;
        body.transform.Rotate(Vector3.up, -yaw * Time.deltaTime);
        body.transform.Rotate(Vector3.right, -pitch * Time.deltaTime);
        Camera.main.transform.Rotate(Vector3.forward, pitch * Time.deltaTime);
    }

    private void UpdatePlayerVelocity()
    {
        Vector3 compoundAccel = vertAccel + horiAccel;
        VelocityChange(bodyRb, compoundAccel);
        VelocityChange(leftRb, compoundAccel);
        VelocityChange(rightRb, compoundAccel);
    }

    private void UpdateAccels()
    {
        vertAccel = vertAccel * accelResetRate;
        horiAccel = horiAccel * accelResetRate;
    }

    private void UpdateRotation()
    {
        float rotationValue = pitch * rotationResetRate * (body.transform.rotation.x % 360);
        body.transform.Rotate(Vector3.right, -rotationValue);
        Camera.main.transform.Rotate(Vector3.forward, rotationValue);
    }

    // Helper methods
    private void VelocityChange(Rigidbody rb, Vector3 accel)
    {
        rb.velocity = rb.velocity + accel;
    }

}
