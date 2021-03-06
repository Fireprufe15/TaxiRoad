﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathByContact : MonoBehaviour {

	public GameObject particle;
	public Transform playerTransform;
	public Text t;
    
    private AudioSource gravel;
	private AudioSource engine;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Spawnable")
		{
			Instantiate(particle, other.gameObject.transform.position, other.gameObject.transform.rotation);
			GameObject.Find("GUI").GetComponent<Animator>().SetTrigger("GameOver");
			AudioSource crash = GameObject.Find("Crash").GetComponent<AudioSource>(); 
			crash.Play();
			Destroy(this.gameObject);
			SinglePlayerScore.isCounting = false;
            RoadCreator.speed = 0;   
			s.gameObject.SetActive(false);
			stopAudio ();
		}
	}
    
    void Start(){
        gravel = GameObject.Find("gravelSound").GetComponent<AudioSource>(); 
		engine = GameObject.Find("engine").GetComponent<AudioSource>(); 
    }
    
    void Update(){
        if (GrassDamage.playerHealth <= 0)
        {
            grassKill();
        }
        
		if (!PositionRaycast.onRoad && !gravel.isPlaying && GrassDamage.playerHealth > 0)
        {
            gravel.Play();            
        }else if (PositionRaycast.onRoad && gravel.isPlaying)
        {
            gravel.Stop();
            CamShake.shake = 0;
        }
    }
    
	public Slider s;

    void grassKill(){
			GameObject.Find("GUI").GetComponent<Animator>().SetTrigger("GameOver");
			AudioSource crash = GameObject.Find("Crash").GetComponent<AudioSource>(); 
			crash.Play();
			Destroy(this.gameObject);
			SinglePlayerScore.isCounting = false;
            RoadCreator.speed = 0;
			stopAudio ();

		if (GrassDamage.playerHealth == 0)
		{
			s.gameObject.SetActive(false);
		}
    }

	void stopAudio()
	{
		// int score = GameObject.Find ("ScoreKeeper").GetComponent<SinglePlayerScore> ().Score;

		updateBoard();

		gravel.Stop ();
		engine.Stop ();
		print ("Fired");
	}

	public void updateBoard()
	{
		t.text = "";
		for (int i = 0; i < 10; i++)
		{
			if (GetHighScores.highScores[i] != 0) {
				//t.text += GetHighScores.highScoreNames[i] + "\t\t\t" + GetHighScores.highScores[i] + "\n";
				t.text += string.Format("{0,-25}{1,5}\n",GetHighScores.highScoreNames[i],GetHighScores.highScores[i]);
			}
			
		}
	}
    
    
}
