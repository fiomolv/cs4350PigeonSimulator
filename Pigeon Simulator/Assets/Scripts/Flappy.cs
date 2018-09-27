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

    public float g;
    public float forwardSpeed;

    public int layerNumber = 8;

    private float yaw = 200;
    private float pitch = 800;
    private float accelResetRate = 0.1f;
    private float rotationResetRate = 0.002f;

    private Vector3 vertAccel;
    private Vector3 horiAccel;
    private Vector3 vertAccelChangeRate = 1.2f * Vector3.up;
    private Vector3 horiAccelChangeRate = 0.9f * Vector3.forward; // Forward was Z
    private Vector3 forwardMovement;

    private Animation leftAnimation;
    private Animation rightAnimation;

    private void Start()
    {
        Physics.IgnoreLayerCollision(layerNumber, layerNumber);

        bodyRb = body.GetComponent<Rigidbody>();
        leftRb = left.GetComponent<Rigidbody>();
        rightRb = right.GetComponent<Rigidbody>();

        Physics.gravity = g * Vector3.down;

        forwardMovement = forwardSpeed * Vector3.right;

        leftAnimation = left.GetComponent<Animation>();
        rightAnimation = right.GetComponent<Animation>();

        leftAnimation["Left"].speed = 0.75f;
        rightAnimation["Right"].speed = 0.75f;
    }

    private void Update()
    {

        //body.transform.Translate(forwardMovement * Time.deltaTime);
        

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

        transform.position += transform.right * Time.deltaTime * forwardSpeed;
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
        float angle = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
        if (angle > -45)
        {
            body.transform.Rotate(Vector3.down, pitch * Time.deltaTime);
        }
        Camera.main.transform.Rotate(Vector3.forward, -pitch * Time.deltaTime);

        leftAnimation.Play(leftAnimation.clip.name);
    }

    private void LiftRight()
    {
        vertAccel = vertAccel + vertAccelChangeRate;
        horiAccel = horiAccel - horiAccelChangeRate;
        
        float angle = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
        if (angle < 45) {
            body.transform.Rotate(Vector3.down, -pitch * Time.deltaTime);
        }

        Camera.main.transform.Rotate(Vector3.forward, pitch * Time.deltaTime);

        rightAnimation.Play(rightAnimation.clip.name);
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
