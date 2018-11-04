using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show: MonoBehaviour {

    public GameObject tooLow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -5.3f)
        {
            Debug.Log("Too Low");
            tooLow.SetActive(true);
        }
        else
        {
            tooLow.SetActive(false);
        }
    }
}
