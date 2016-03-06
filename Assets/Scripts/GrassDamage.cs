using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GrassDamage : MonoBehaviour {
    
	public static int playerHealth = 100;
	public static int setHP;
    
    public float damageRate;
    public int damageAmount;
	public Slider s;
	public Image bodyColor;
	public int playerHp;
    
    
    private float nextDamage;


	// Use this for initialization
	void Start () {
		setHP = playerHp;
		playerHealth = playerHp;
		s.maxValue = playerHp;
	}
	
	// Update is called once per frame
	void Update () {
        if (!PositionRaycast.onRoad)
        {
            if (nextDamage == 0)
           {
               nextDamage = damageRate+Time.time;
           }
           if (CamShake.shake == 0.0f)
           {
               CamShake.shake = 2;
           }
        }else{
            nextDamage = 0;
        }
	   if (!PositionRaycast.onRoad && Time.time >= nextDamage)
       {           
           playerHealth -= damageAmount;
			updateSlider();

           nextDamage += damageRate;
           
       }
       if (PositionRaycast.onRoad)
       {
           CamShake.shake = 0.0f;
       }
	}

	public void updateSlider()
	{
		s.value = playerHealth;
		
		if(playerHealth > playerHp/2)
		{
			bodyColor.color = new Color32(115,227,125,255);
		}
		else if(playerHealth > playerHp/4)
		{
			bodyColor.color = new Color32(255,150,30,255);
		}
		else if(playerHealth <= playerHp/4)
		{
			bodyColor.color = new Color32(255,0,0,255);
		}
	}
}
