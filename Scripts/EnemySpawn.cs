using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject[] PickUp;
    public float spawnTime = 3f;
    private Vector3 spawnPosition; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        spawnPosition.x = Random.Range(-6, 6);
        spawnPosition.y = Random.Range(-4, 4);
        spawnPosition.z = Random.Range(0, 0);

        Instantiate(PickUp[Random.Range(0, PickUp.Length - 1)], spawnPosition, Quaternion.identity);

    }
}
