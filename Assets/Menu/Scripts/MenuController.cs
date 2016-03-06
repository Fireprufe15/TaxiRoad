using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject creditsGO;
    public GameObject popUp;

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
    
    public void resetProgram(){
        PlayerPrefs.DeleteAll();
		popUp.SetActive (true);
    }
    
    public void closePopup()
    {
		popUp.SetActive (false);
    }
}
