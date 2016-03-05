using UnityEngine;
using System.Collections;

public class DeathByContact : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Spawnable")
		{
			AudioSource crash = GameObject.Find("Crash").GetComponent<AudioSource>(); 
			crash.Play();
			Destroy(this.gameObject);
			SinglePlayerScore.isCounting = false;
		}
	}
}
