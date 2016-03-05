using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Image i;

	public void StartGame()
	{
		i.gameObject.SetActive (true);
		Application.LoadLevel ("game");

	}
}
