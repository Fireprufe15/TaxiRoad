using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ObjectSpawn : MonoBehaviour {

	GameObject thisTile;

	// Use this for initialization
	void Start () {
		thisTile = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (ObjectTimer.canSpawn && thisTile.transform.position.z <= -150f )
        {
			int spawnIndex = Mathf.RoundToInt(Random.Range(0, ObjectTimer.spawnedObjectList.Count));
			GameObject spawnedItem = (GameObject)Instantiate(ObjectTimer.spawnedObjectList[spawnIndex]/**, thisTile.transform.position, Quaternion.Euler(0,90,0)**/);
			spawnedItem.transform.SetParent(thisTile.transform);
			float offSet = Random.Range(11,RoadCreator.globalHorTiles*10f-22f);
			if (RoadCreator.globalHorTiles == 14)
            {
                spawnedItem.transform.position = new Vector3(transform.position.x+offSet, transform.position.y+8f,transform.position.z+1f);
            }else
            {
                spawnedItem.transform.position = new Vector3(transform.position.x, transform.position.y+8f,transform.position.z+1f);
            }
			ObjectTimer.canSpawn = false;
            
        }
	}
}
