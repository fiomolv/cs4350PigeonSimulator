using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private Quaternion rotation;

    void Start ()
    {
        offset = transform.position - player.transform.position;
        rotation = transform.rotation;
    }
    
    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = rotation;
    }
}