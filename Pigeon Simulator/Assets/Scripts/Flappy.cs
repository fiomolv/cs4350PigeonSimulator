using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{

    public GameObject left;
    public GameObject right;

    public GameObject body;

    public GameObject pot;
    public GameObject window;

    public Rigidbody bodyRb;
    public Rigidbody leftRb;
    public Rigidbody rightRb;

    public float g;
    public float forwardSpeed;

    public int layerNumber = 8;

    private float yaw = 50;
    private float pitch = 350;
    private float accelResetRate = 0.1f;
    private float rotationResetRate = 0.002f;

    private Vector3 vertAccel;
    private Vector3 horiAccel;
    private Vector3 vertAccelChangeRate = 1.2f * Vector3.up;
    private Vector3 horiAccelChangeRate = 0.9f * Vector3.forward; // Forward was Z
    private Vector3 forwardMovement;

    private Animation anim;
    private Animation lanim;
    private Animation ranim;
    public AnimationClip lb;
    public AnimationClip rb;

    private void Start()
    {
        Physics.IgnoreLayerCollision(layerNumber, layerNumber);

        bodyRb = gameObject.GetComponent<Rigidbody>();
        //leftRb = left.GetComponent<Rigidbody>();
        //rightRb = right.GetComponent<Rigidbody>();

        Physics.gravity = g * Vector3.down;

        forwardMovement = forwardSpeed * Vector3.right;

        anim = body.GetComponent<Animation>();
        lanim = left.GetComponent<Animation>();
        ranim = right.GetComponent<Animation>();
    }

    private void Update()
    {
        if (transform.position.x < window.transform.position.x) {
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

            //UpdateRotation();
            UpdatePlayerVelocity();
            UpdateAccels();

            gameObject.transform.position += gameObject.transform.right * Time.deltaTime * forwardSpeed;
        }
        else {
			PlayerPrefs.SetInt("highest", 0); // reset history record 
			UpdatePlayerVelocity();
            UpdateAccels();

            gameObject.transform.Rotate(transform.forward, -30 * Time.deltaTime);
            //Camera.main.transform.Rotate(Vector3.forward, 40 * Time.deltaTime);
            gameObject.transform.position += gameObject.transform.right * Time.deltaTime * forwardSpeed;
        }
    }

	private void LiftUp()
	{
		vertAccel = vertAccel + vertAccelChangeRate / 2;
        gameObject.transform.Rotate(Vector3.up, yaw * Time.deltaTime);
	}

    private void LiftLeft()
    {
        lanim.Play(lanim.clip.name);
        anim.Play(lb.name);
        vertAccel = vertAccel + vertAccelChangeRate;
        horiAccel = horiAccel + horiAccelChangeRate;
        float angle = Vector3.SignedAngle(Vector3.forward, gameObject.transform.forward, Vector3.up);
        if (angle > -35)
        {
            gameObject.transform.Rotate(transform.up, -pitch * Time.deltaTime);
        }

        //Camera.main.transform.Rotate(Vector3.forward, -pitch * Time.deltaTime);
    }

    private void LiftRight()
    {
        ranim.Play(ranim.clip.name);
        anim.Play(rb.name);
        vertAccel = vertAccel + vertAccelChangeRate;
        horiAccel = horiAccel - horiAccelChangeRate;

        float angle = Vector3.SignedAngle(Vector3.forward, gameObject.transform.forward, Vector3.up);
        if (angle < 35) {
            gameObject.transform.Rotate(transform.up, pitch * Time.deltaTime);
        }
        
        //Camera.main.transform.Rotate(Vector3.forward, pitch * Time.deltaTime);
    }

    private void UpdatePlayerVelocity()
    {
        Vector3 compoundAccel = vertAccel + horiAccel;
        VelocityChange(bodyRb, compoundAccel);
        //VelocityChange(leftRb, compoundAccel);
        //VelocityChange(rightRb, compoundAccel);
    }

    private void UpdateAccels()
    {
        vertAccel = vertAccel * accelResetRate;
        horiAccel = horiAccel * accelResetRate;
    }

    private void UpdateRotation()
    {
        float rotationValue = pitch * rotationResetRate * (gameObject.transform.rotation.x % 360);
        gameObject.transform.Rotate(Vector3.right, -rotationValue);
        Camera.main.transform.Rotate(Vector3.forward, rotationValue);
    }

    // Helper methods
    private void VelocityChange(Rigidbody rb, Vector3 accel)
    {
        rb.velocity = rb.velocity + accel;
    }
}
