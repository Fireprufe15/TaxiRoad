using UnityEngine;
using System.Collections;

public class ReloadLevel : MonoBehaviour {

	public void Reload(){
		
		GrassDamage.playerHealth = 100;
		CamShake.shake = 0;
		RoadCreator.difficulty = 1;
		Application.LoadLevel (Application.loadedLevel);
	}

}
