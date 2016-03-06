using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject creditsGO;
	public GameObject settingsGO;

	public void StartGame()
	{
		GameObject.Find("Canvas_menu").SetActive (false);
	}

	public void ShowCredits()
	{
		creditsGO.SetActive (true);
		settingsGO.SetActive (false);
	}

	public void ShowSettings()
	{
		settingsGO.SetActive (true);
		creditsGO.SetActive (false);
	}
}
