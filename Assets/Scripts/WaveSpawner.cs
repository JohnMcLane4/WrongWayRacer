using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject[] vehiclesToSpawn;
    public Transform[] spawnPositions;
    int vehiclesToSpawnNumber;

    float spawndelay;
    float timer;    

    // Use this for initialization
    void Start ()
    {
        //spawndelay = Random.Range(1f, 3f);
        timer = spawndelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        spawndelay = Random.Range(0.45f, 1.5f);


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Transform spawnPosition = spawnPositions[(int)Random.Range(0, spawnPositions.Length)].transform;
            vehiclesToSpawnNumber = Random.Range(0, vehiclesToSpawn.Length);
            Instantiate(vehiclesToSpawn[vehiclesToSpawnNumber], spawnPosition.position, transform.rotation);
            timer = spawndelay;
        }
	}
}
