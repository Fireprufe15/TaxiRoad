using UnityEngine;
using System.Collections;

public class DeathByContact : MonoBehaviour {

	public GameObject particle;
	public Transform playerTransform;
    
    private AudioSource gravel;

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
    
    void Start(){
        gravel = GameObject.Find("gravelSound").GetComponent<AudioSource>(); 
    }
    
    void Update(){
        if (GrassDamage.playerHealth <= 0)
        {
            grassKill();
        }
        
        if (!PositionRaycast.onRoad && !gravel.isPlaying)
        {
            gravel.Play();            
        }else if (PositionRaycast.onRoad && gravel.isPlaying)
        {
            gravel.Stop();
            CamShake.shake = 0;
        }
    }
    
    void grassKill(){
			GameObject.Find("GUI").GetComponent<Animator>().SetTrigger("GameOver");
			AudioSource crash = GameObject.Find("Crash").GetComponent<AudioSource>(); 
			crash.Play();
			Destroy(this.gameObject);
			SinglePlayerScore.isCounting = false;
            RoadCreator.speed = 0;
    }
    
    
}
