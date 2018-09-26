using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFallDown : MonoBehaviour {

    public GameObject body;
    public GameObject tree;
    public AudioClip audio;
    public int distance;
    public int fallDownSpeed;

    private bool startFallDown;
    private bool playAudio;

    private AudioSource audioSource;

    void Start()
    {
        startFallDown = false;
        playAudio = false;
        audioSource = (AudioSource)tree.AddComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.loop = false;
    }

	void Update () {
		if(!startFallDown && body.transform.position.x > tree.transform.position.x - distance)
        {
            startFallDown = true;
        }

        if (startFallDown && tree.transform.rotation.z < 0.4)
        {
            tree.transform.Rotate(-Vector3.right * Time.deltaTime * fallDownSpeed, Space.World);
        }

        if (!playAudio && startFallDown)
        {
            playAudio = true;
            audioSource.Play(0);
        }
	}
}
