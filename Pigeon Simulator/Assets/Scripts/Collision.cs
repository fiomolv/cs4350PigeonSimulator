using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{

	void OnCollisionEnter(UnityEngine.Collision col)
	{
		if (col.gameObject.name != "Left" && col.gameObject.name != "Right")
		{
			Debug.Log("Collision detected!");
			Debug.Log(col.gameObject.name);

            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("score", (int)(Time.timeSinceLevelLoad * 5));

            SceneManager.LoadScene("Death");
        }
	}

}

