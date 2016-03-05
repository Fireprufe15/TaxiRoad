using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectTimer : MonoBehaviour {

    public static bool canSpawn = false;
    public static List<GameObject> spawnedObjectList;

    public float timeBetweenSpawns;
	public List<GameObject> initList;
    private float nextSpawnTime;



	// Use this for initialization
	void Start () {
        nextSpawnTime = timeBetweenSpawns;
		spawnedObjectList = initList;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextSpawnTime)
        {
            canSpawn = true;
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
	}
}
