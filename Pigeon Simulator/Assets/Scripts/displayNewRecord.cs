using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayNewRecord : MonoBehaviour {

	public GameObject newRecord;

	void Start () {
		if (PlayerPrefs.GetInt("isNewRecord", 0) == 1)
		{
			Debug.Log("new record display true");
			newRecord.SetActive(true);
		}
		else
		{
			Debug.Log("new record display false");
			newRecord.SetActive(false);
		}
		PlayerPrefs.SetInt("isNewRecord", 0);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
