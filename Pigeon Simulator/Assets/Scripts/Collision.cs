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
        if (col.gameObject.name == "Soup") {
            SceneManager.LoadScene("Endpage");
        }
		else if (col.gameObject.name != "Left" 
            && col.gameObject.name != "Right"
            && col.gameObject.name != "Body"
            && col.gameObject.name != "Player")
		{
			Debug.Log("Collision detected!");
			Debug.Log(col.gameObject.name);

            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

			int currentScore = (int)(Time.timeSinceLevelLoad * 5);
			PlayerPrefs.SetInt("score", currentScore);

			// set highest score
			if (currentScore > PlayerPrefs.GetInt("highest", 0))
				PlayerPrefs.SetInt("highest", currentScore);

			// play hit audio
			audioSource.Play();
	
			// load death scene
			SceneManager.LoadScene("Death");
        }
	}

}

