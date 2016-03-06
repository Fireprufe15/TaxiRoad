using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReloadLevel : MonoBehaviour {

	public void Reload(){
		
		GrassDamage.playerHealth = 100;
		CamShake.shake = 0;
		RoadCreator.difficulty = 1;
		Application.LoadLevel (Application.loadedLevel);
	}

	public GameObject c;
	public InputField name;
	public GameObject sc;
	public Text t;

	public void HideCanvas()
	{
		print (sc.GetComponent<SinglePlayerScore> ().Score + " " + name.text);
		GetHighScores.addHighScore(sc.GetComponent<SinglePlayerScore>().Score,name.text);
		GetHighScores.refresh ();

		t.text = "";
		for (int i = 0; i < 10; i++)
		{
			if (GetHighScores.highScores[i] != 0) {
				//t.text += GetHighScores.highScoreNames[i] + "\t\t\t" + GetHighScores.highScores[i] + "\n";
				t.text += string.Format("{0,-25}{1,5}\n",GetHighScores.highScoreNames[i],GetHighScores.highScores[i]);
			}
			
		}

		c.SetActive (false);
	}

	public void mainMenu()
	{
		Application.LoadLevel ("Menu");
	}
}
