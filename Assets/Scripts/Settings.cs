using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour {

	static public bool sound;
	static public float volume;


	public void SoundOn()
	{
		sound = GameObject.Find ("Toggle").GetComponent<Toggle> ().isOn;
	}

	public void setVolume()
	{
		volume = GameObject.Find ("Slider").GetComponent<Slider> ().value;
	}
}
