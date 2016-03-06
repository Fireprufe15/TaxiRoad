using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ObjectSpawn : MonoBehaviour {

	GameObject thisTile;
    public int maxSpawnRow;
    private int maxSpawnIndex;
    private int furthestTile;

	// Use this for initialization
	void Start () {
		thisTile = this.gameObject;   
        furthestTile = RoadCreator.globalVertTiles*RoadCreator.globalHorTiles ;  
        maxSpawnIndex = maxSpawnRow * RoadCreator.globalHorTiles;  
	}
	
	// Update is called once per frame
	void Update () {                
        if (ObjectTimer.canSpawn)
        {
			int spawnIndex = Mathf.RoundToInt(Random.Range(0, ObjectTimer.spawnedObjectList.Count-2));
            spawnSpecific(spawnIndex);	
            ObjectTimer.canSpawn = false;		   
        }
        if (ObjectTimer.canSpawnHealth)
        {
            int spawnIndex = ObjectTimer.spawnedObjectList.Count - 2;
            spawnSpecific(spawnIndex);
            ObjectTimer.canSpawnHealth = false;
        }
        if (ObjectTimer.canSpawnScore)
        {
            int spawnIndex = ObjectTimer.spawnedObjectList.Count - 1;
            spawnPowerupAnywhere(spawnIndex);
            ObjectTimer.canSpawnScore = false;
        }
	}
    
    void spawnSpecific(int objectIndex){        
        int spawnTileIndex = Mathf.RoundToInt(Random.Range(900, 1100 ));
        GameObject tileToSpawnOn = GameObject.Find(spawnTileIndex.ToString());
        GameObject spawnedItem = (GameObject)Instantiate(ObjectTimer.spawnedObjectList[objectIndex]);
        spawnedItem.transform.SetParent(tileToSpawnOn.transform);
        spawnedItem.transform.position = new Vector3(tileToSpawnOn.transform.position.x, tileToSpawnOn.transform.position.y+8f,tileToSpawnOn.transform.position.z);

    }
    
    void spawnPowerupAnywhere(int objectIndex){
        int spawnTileIndex = Mathf.RoundToInt(Random.Range(900, 1100 ));
        GameObject tileToSpawnOn = GameObject.Find(spawnTileIndex.ToString());
        GameObject spawnedItem = (GameObject)Instantiate(ObjectTimer.spawnedObjectList[objectIndex]);
        spawnedItem.transform.SetParent(tileToSpawnOn.transform);
        int randomSpawnLocale = Random.Range(1,11);
        if (randomSpawnLocale >= 1 && randomSpawnLocale <= 2 )
        {
            spawnedItem.transform.position = new Vector3(tileToSpawnOn.transform.position.x, tileToSpawnOn.transform.position.y+8f,tileToSpawnOn.transform.position.z);
        }
        else if(randomSpawnLocale >=3 && randomSpawnLocale <= 6)
        {
            spawnedItem.transform.position = new Vector3(Random.Range(-10*RoadCreator.tileBendingSpawn, (RoadCreator.currentOffset-RoadCreator.globalHorTiles/2)*10), tileToSpawnOn.transform.position.y+8f,tileToSpawnOn.transform.position.z);
        }
        else if(randomSpawnLocale >=7 && randomSpawnLocale <= 10)
        {
            spawnedItem.transform.position = new Vector3(Random.Range(10*RoadCreator.tileBendingSpawn, (RoadCreator.currentOffset+RoadCreator.globalHorTiles/2)*10), tileToSpawnOn.transform.position.y+8f,tileToSpawnOn.transform.position.z);
        }
    }
}
