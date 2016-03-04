using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RoadCreator : MonoBehaviour {

    public int horizontalTiles;
    public int verticalTiles;
    public float initSpeed;    
    public GameObject tile;
    public int tileBending;
    public int chunks;

    public static float speed;

    private Queue<GameObject> roadPieces;
    private float spawnStartX;
    private float spawnStartY;
    private int verticalOffset = 0;
    private int chunkCount = 0;
    // Use this for initialization
	void Start () {
        //randomiser = new Random();
        speed = initSpeed;
        roadPieces = new Queue<GameObject>();        
        spawnStartX = horizontalTiles * 10 / 2;
        spawnStartY = verticalTiles * 10 / 2;
        for (int i = 0; i < verticalTiles; i++)
        {
            for (int j = 0; j < horizontalTiles; j++)
            {
                Vector3 spawnPosition = new Vector3(-((j * 10) - spawnStartX), 0f, -(i *10 - spawnStartY));
                roadPieces.Enqueue((GameObject)Instantiate(tile, spawnPosition, Quaternion.identity));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        replace();
        move();        
	}

    void move()
    {
        foreach (GameObject piece in roadPieces)
        {
            piece.transform.position = new Vector3(piece.transform.position.x, 0f, piece.transform.position.z + speed*Time.deltaTime);
        }
    }

    void replace()
    {
        if (roadPieces.Peek().transform.position.z >= 10 * (verticalTiles / 2)) 
        {
            if (chunkCount > chunks)
            {
                int direction;
                do
                {
                    direction = Mathf.RoundToInt(Random.Range(-1, 2));
                    Debug.Log(direction);
                    verticalOffset += direction;
                } while (verticalOffset < -tileBending || verticalOffset > tileBending);
                chunkCount = 0;
            }
            else
            {
                chunkCount++;
            }
            
            
            for (int i = 0; i < horizontalTiles; i++)
            {
                Vector3 spawnPosition = new Vector3(((i+1+verticalOffset) * 10) - spawnStartX, 0f, roadPieces.Peek().transform.position.z - verticalTiles*10f+10f);
                Destroy(roadPieces.Dequeue());                
                roadPieces.Enqueue((GameObject)Instantiate(tile, spawnPosition, Quaternion.identity));
            }                      
        }
    }
}
