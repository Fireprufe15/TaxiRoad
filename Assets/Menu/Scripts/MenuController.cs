using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {


	public void StartGame()
	{
		GameObject.Find("Canvas_menu").SetActive (false);
	}
}
