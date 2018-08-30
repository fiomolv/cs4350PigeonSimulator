using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour {

    private GameObject left;
    private GameObject right;

    private GameObject body;

    private void Start() {

        left = GameObject.Find("Left");
        right = GameObject.Find("Right");
        body = GameObject.Find("Body");
    }

    private void FixedUpdate() {

    }
}
