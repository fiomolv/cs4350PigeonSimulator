using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetScore : MonoBehaviour {

    public Text score;

	void Start () {
        if (SceneManager.GetActiveScene().name.Equals("Death"))
        {
			score.text = "Score: " + PlayerPrefs.GetInt("score");
		} else {
            score.text = "Score: 0";

		}
		
    }

    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Death"))
        {
            score.text = "Score: " + (int)(Time.timeSinceLevelLoad * 5);
        }
    }
}
