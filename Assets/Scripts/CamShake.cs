using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {
    public static float shake;
    public float shakeAmount;
    public float decreaseFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if (shake > 0)
       {
           transform.localPosition = Random.insideUnitSphere*shakeAmount;
       }else{
           shake =0.0f;
       }
	}
}
