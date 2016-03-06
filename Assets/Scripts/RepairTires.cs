using UnityEngine;
using System.Collections;

public class RepairTires : MonoBehaviour {

	public int hpReturned;
	public GameObject aus;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if (GrassDamage.playerHealth < GrassDamage.setHP)
			{
				GrassDamage.playerHealth += hpReturned;

				if (GrassDamage.playerHealth > GrassDamage.setHP)
					GrassDamage.playerHealth = GrassDamage.setHP;

				GameObject.Find("OffroadDamage").GetComponent<GrassDamage>().updateSlider();
			}

			
			GameObject.Find("PowerUp_a").GetComponent<AudioSource>().Play();
			Destroy(this.gameObject);
		}
	}
}
