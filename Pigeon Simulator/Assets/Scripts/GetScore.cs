using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

    public Text score;

	void Start () {
        score.text = "Score: " + PlayerPrefs.GetInt("score");
    }
}
