using UnityEngine;
using System.Collections;

public class GrassDamage : MonoBehaviour {
    
    public static int playerHealth = 100;
    
    public float damageRate;
    public int damageAmount;
    
    
    private float nextDamage;


	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        if (!PositionRaycast.onRoad)
        {
            if (nextDamage == 0)
           {
               nextDamage = damageRate+Time.time;
           }
        }else{
            nextDamage = 0;
        }
	   if (!PositionRaycast.onRoad && Time.time >= nextDamage)
       {           
           playerHealth -= damageAmount;
           nextDamage += damageRate;
           Debug.Log(playerHealth);
           if (CamShake.shake == 0.0f)
           {
               CamShake.shake = 2;
           }
       }
       
       
       
       
	}
}
