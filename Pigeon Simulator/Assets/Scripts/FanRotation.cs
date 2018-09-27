using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour {

    public GameObject fan;
    public int speed;

	// Update is called once per frame
	void Update () {
        fan.transform.Rotate(Vector3.right * Time.deltaTime * speed);
	}
}
