using UnityEngine;
using System.Collections;

public class PositionRaycast : MonoBehaviour {
    
    public static bool onRoad;   

	// Use this for initialization
	void Start () {
	   onRoad = true;
	}
	
	// Update is called once per frame
	void Update () {
        castRay();
	}
    
    void OnDestroy(){
        onRoad = false;
    }
    
    void castRay(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.name == "grass" || hit.collider.gameObject.name == "grass 1")
            {
                onRoad = false;
            }else{
                onRoad = true;
            }
        }else{
            onRoad = false;
        }
    }
}
