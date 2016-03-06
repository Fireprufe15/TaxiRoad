using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject creditsGO;

	public void StartGame()
	{
		GameObject.Find("Canvas_menu").SetActive (false);
		creditsGO.SetActive (false);

	}

	public void ShowCredits()
	{
		creditsGO.SetActive (true);
	}

	public void killProgram()
	{
		Application.Quit();
	}
}
