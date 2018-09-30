using UnityEngine;
using System;

public class TreeFallDown : MonoBehaviour {

    public GameObject body;
    public GameObject tree;
    public AudioClip audio;
    public int distance;
    public int fallDownSpeed;
    public int direction;

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
        audioSource.playOnAwake = false;
    }

	void Update () {
        if (!startFallDown && body.transform.position.x > tree.transform.position.x - distance)
        {
            startFallDown = true;
        }

        if (startFallDown)
        {
            if (Math.Abs(tree.transform.rotation.z)< 0.5)
            {
                tree.transform.Rotate(Vector3.right * Time.deltaTime * fallDownSpeed * direction, Space.World);
                tree.transform.Translate(Vector3.up * Time.deltaTime * -3 * direction, Space.World);
            }
        }

        if (!playAudio && startFallDown)
        {
            playAudio = true;
            audioSource.Play(0);
        }
	}
}
