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
    private float forestoffset = 275f;
    private float offsetx;
    private Quaternion rotation;
    private float initx;

    // Use this for initialization
    void Start()
    {
        offsetx = transform.position.x - player.transform.position.x;
        initx = transform.position.x;
        //rotation = transform.rotation;
        SpawnForest();
        //StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offsetx, 
                                         transform.position.y, 
                                         transform.position.z);
        if (transform.position.x - initx > forestoffset) {
            initx = transform.position.x;
            SpawnForest();
        }
    }

    void SpawnForest() {
        Vector3 spawnPosition = new Vector3(forestoffset,
                                                0,
                                                0);
        Quaternion rot = Quaternion.Euler(0, 180, 0);

        if (Random.Range(0, 1) > 0.5)
        {
            rot = Quaternion.Euler(0, 0, 0);
        }

        Instantiate(enemies[randEnemy], spawnPosition + gameObject.transform.position, rot);
    }


    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {

            Vector3 spawnPosition = new Vector3(gameObject.transform.position.x + forestoffset,
                                                0,
                                                0);
            Quaternion rot = Quaternion.Euler(0, 180, 0);

            if (Random.Range(0, 1) > 0.5) {
                rot = Quaternion.Euler(0, 0, 0);
            }

            Instantiate(enemies[randEnemy], spawnPosition + gameObject.transform.position, rot);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
