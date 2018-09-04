using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

	void OnCollisionEnter(UnityEngine.Collision col)
	{
		if (col.gameObject.name != "Left" && col.gameObject.name != "Right")
		{
			Debug.Log("Collision detected!");
			Debug.Log(col.gameObject.name);
			//TODO: ADD DEATH UI

		}

	}

}

