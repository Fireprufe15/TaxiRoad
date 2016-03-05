using UnityEngine;
using System.Collections;

public class DeathByContact : MonoBehaviour {

	public GameObject particle;
	public Transform playerTransform;

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
		}
	}
}
