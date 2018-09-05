using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject player;

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    private int randEnemy;

    private Vector3 offset;
    private Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        rotation = transform.rotation;

        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = rotation;

        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, enemies.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(0, spawnValues.x),
                                                Random.Range(-spawnValues.y, spawnValues.y),
                                                Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemies[randEnemy], spawnPosition + gameObject.transform.position,
                gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
