using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour {

    public GameObject left;
    public GameObject right;

    public GameObject body;

    public Rigidbody bodyRb;
    public Rigidbody leftRb;
    public Rigidbody rightRb;

    private float forwardSpeed = 0.1f;
    private float upSpeed = 1;
    private float yaw = 20;
    private float pitch = 20;

    private Vector3 upMovement;
    private Vector3 forwardMovement;

    private void Start() {

        left = GameObject.Find("Left");
        right = GameObject.Find("Right");
        body = GameObject.Find("Body");

        //camera = body.GetComponent<Camera>();

        bodyRb = body.GetComponent<Rigidbody>();
        leftRb = left.GetComponent<Rigidbody>();
        rightRb = right.GetComponent<Rigidbody>();

        Physics.gravity = 0.01f * Vector3.down;

        upMovement = upSpeed * Vector3.up;
        forwardMovement = forwardSpeed * Vector3.right;
    }

    private void Update() {

        body.transform.Translate(forwardMovement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            // Left
            LiftLeft();

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            // Right
            LiftRight();
            
    }

    private void LiftLeft() {
        body.transform.Translate(upMovement * Time.deltaTime);
        body.transform.Rotate(Vector3.up, yaw * Time.deltaTime);
        body.transform.Rotate(Vector3.right, -pitch * Time.deltaTime);
        Camera.main.transform.Rotate(Vector3.forward, pitch * Time.deltaTime);
    }

    private void LiftRight() {
        body.transform.Translate(upMovement * Time.deltaTime);
        body.transform.Rotate(Vector3.up, -yaw * Time.deltaTime);
        body.transform.Rotate(Vector3.right, pitch * Time.deltaTime);
        Camera.main.transform.Rotate(Vector3.forward, -pitch * Time.deltaTime);
    }

}
