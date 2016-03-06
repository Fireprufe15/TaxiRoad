using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectTimer : MonoBehaviour {

    public static bool canSpawn = false;
    public static bool canSpawnHealth = false;
    public static bool canSpawnScore = false;
    public static List<GameObject> spawnedObjectList;

    public float timeBetweenHealthSpawns;
    public float timeBetweenScoreSpawns;
    public float timeBetweenSpawns;
	public List<GameObject> initList;
    private float nextSpawnTime;
    private float nextHealthSpawnTime;
    private float nextScoreSpawnTime;



	// Use this for initialization
	void Start () {
        InvokeRepeating("IncSpawnFrequency",RoadCreator.diffCurveRateGlobal,RoadCreator.diffCurveRateGlobal);
        nextSpawnTime = timeBetweenSpawns;
        nextHealthSpawnTime = timeBetweenHealthSpawns;
        nextScoreSpawnTime = timeBetweenScoreSpawns;
		spawnedObjectList = initList;
	}
	
	// Update is called once per frame
	void Update () {        
        if (Time.time >= nextSpawnTime)
        {
            canSpawn = true;
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
        if (Time.time >= nextHealthSpawnTime)
        {
            if (GrassDamage.playerHealth < 90)
            {
                canSpawnHealth = true;
            }            
            nextHealthSpawnTime = Time.time + timeBetweenHealthSpawns;
        }
        if (Time.time >= nextScoreSpawnTime)
        {
            canSpawnScore = true;
            nextScoreSpawnTime = Time.time + Random.Range(3f, timeBetweenScoreSpawns);
        }
	}
    
    void IncSpawnFrequency(){
        if (timeBetweenSpawns > 0.5f)
        {
            timeBetweenSpawns = timeBetweenSpawns - (RoadCreator.difficulty/200f);
        }       
    }
}
