using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SinglePlayerScore : MonoBehaviour {
	public static bool isCounting = true;
	[HideInInspector] public int Score = 0;
	public float scoreTimeIncrements;
	public int scoreUnitIncrements;

	Text scoreText;
	float nextScoreUpdate;

	void Start () {
		nextScoreUpdate = scoreTimeIncrements;
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
	}


	void Update () {
        if (PositionRaycast.onRoad != true)
        {
            isCounting = false;
        }else
        {
            isCounting = true;
        }
		if (Time.time >= nextScoreUpdate && isCounting) {
			Score += scoreUnitIncrements;
			scoreText.text = "Score: " + Score;

			nextScoreUpdate = Time.time + scoreTimeIncrements;
		}
	}
}
