using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public int layerNumber = 8; // Ignore player layer collision.
	public AudioClip hit;
	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(UnityEngine.Collision col)
	{
        Physics.IgnoreLayerCollision(layerNumber, layerNumber);
		if (col.gameObject.name != "Left" 
            && col.gameObject.name != "Right"
            && col.gameObject.name != "Body"
            && col.gameObject.name != "Player")
		{
			Debug.Log("Collision detected!");
			Debug.Log(col.gameObject.name);

            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("score", (int)(Time.timeSinceLevelLoad * 5));
			audioSource.Play();
			SceneManager.LoadScene("Death");
        }
	}

}

