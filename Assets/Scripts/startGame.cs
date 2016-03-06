using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour {
	
	public Image i;

	public void beginGame()
	{
		i.gameObject.SetActive (true);
		Application.LoadLevel("Game");
	}
}
