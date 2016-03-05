using UnityEngine;
using System.Collections;

public class ReloadLevel : MonoBehaviour {

	public void Reload(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
