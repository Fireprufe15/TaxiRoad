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
    public float diffCurveAmmount;
    public float diffCurveRate;
    public float maxSpeed;
    public float minTiles;

    public static float speed;
	public static int globalHorTiles;
    public static int globalVertTiles;
    public static float difficulty = 1f;
    public static float diffCurveRateGlobal;
    public static int tileBendingSpawn;
    public static int currentOffset;

    private Queue<GameObject> roadPieces;
    private float spawnStartX;
    private float spawnStartY;
    private int verticalOffset = 0;
    private int chunkCount = 0;
    private int prevDir = 0;
    private int originalHorTiles;

    // Use this for initialization
	void Start () {
        originalHorTiles = horizontalTiles;
        tileBendingSpawn = tileBending;
        globalVertTiles = verticalTiles;
        diffCurveRateGlobal = diffCurveRate;
        InvokeRepeating("difficultyIncrease",2,diffCurveRate);
		globalHorTiles = horizontalTiles;
        speed = initSpeed;
        roadPieces = new Queue<GameObject>();        
        spawnStartX = horizontalTiles * 10 / 2;
        spawnStartY = verticalTiles * 10 / 2;
        for (int i = 0; i < verticalTiles; i++)
        {
            for (int j = 0; j < horizontalTiles; j++)
            {
                Vector3 spawnPosition = new Vector3(-((j * 10) - spawnStartX), -5f, -(i *10 - spawnStartY));
                roadPieces.Enqueue((GameObject)Instantiate(tile, spawnPosition, Quaternion.identity));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        replace();                
        move();    
        globalHorTiles = horizontalTiles;    
	}

    void move()
    {
        int i = 0;
        foreach (GameObject piece in roadPieces)
        {            
            piece.name = (i + globalHorTiles).ToString();
            piece.transform.position = new Vector3(piece.transform.position.x, -5f, piece.transform.position.z + speed*Time.deltaTime);
            i++;
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
                    int min = -1, max = 2;   
                    if (prevDir == 1)
                    {
                        max = 1;
                    }else if (prevDir == -1)
                    {
                        min = 0;
                    }                
                    direction = Mathf.RoundToInt(Random.Range(min, max));
                    verticalOffset += direction;
                    currentOffset = verticalOffset;
                } while (verticalOffset < -tileBending || verticalOffset > tileBending);
                chunkCount = 0;
            }
            else
            {
                chunkCount++;
            }
            
            
            for (int i = 0; i < horizontalTiles; i++)
            {
                Vector3 spawnPosition = new Vector3(((i+1+verticalOffset) * 10) - spawnStartX, -5f, roadPieces.Peek().transform.position.z - verticalTiles*10f+10f);
                Destroy(roadPieces.Dequeue());   
                GameObject roadPieceNew = (GameObject)Instantiate(tile, spawnPosition, Quaternion.identity);
                roadPieceNew.name = i.ToString();             
                roadPieces.Enqueue(roadPieceNew);
            }                      
        }
    }
    
    void difficultyIncrease(){
        difficulty += diffCurveAmmount;
        speedIncrease();
        shorterRoad();
    }
    
    void speedIncrease(){
        if (speed < maxSpeed)
        {
            speed = speed+difficulty;            
        }
    }
    
    void shorterRoad(){
        if (horizontalTiles > minTiles)
        {
            horizontalTiles = originalHorTiles - ((int)Mathf.Floor(difficulty*2f)-1);            
        }
    }
}
