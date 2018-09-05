using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{

	void OnCollisionEnter(UnityEngine.Collision col)
	{
		if (col.gameObject.name != "Left" 
            && col.gameObject.name != "Right"
            && col.gameObject.name != "Body")
		{
			Debug.Log("Collision detected!");
			Debug.Log(col.gameObject.name);
            SceneManager.LoadScene(2);
        }
	}

}

