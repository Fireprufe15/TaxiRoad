using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public int scoreInc;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject.Find("ScoreKeeper").GetComponent<SinglePlayerScore>().Score += scoreInc;
			GameObject.Find("PowerUp_a").GetComponent<AudioSource>().Play();
			Destroy(this.gameObject);
		}
	}
}
