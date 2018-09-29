using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highestScore : MonoBehaviour {

	// Use this for initialization
	public Text highest;
	void Start () {
		highest.text = "Histroy Record: " + PlayerPrefs.GetInt("highest", 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
