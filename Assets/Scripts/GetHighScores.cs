using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetHighScores : MonoBehaviour {

    public static List<int> highScores;
    public static List<string> highScoreNames;

	// Use this for initialization
	void Start () {
	   highScores = new List<int>();
       for (int i = 0; i < 10; i++)
       {
           string highScoreKey = "highScore"+i.ToString();
           string highScoreNameKey = "highScoreName"+i.ToString();
           highScores.Add(PlayerPrefs.GetInt(highScoreKey,0));
           highScoreNames.Add(PlayerPrefs.GetString(highScoreNameKey, ""));
           
       }
       
	}
    
    static void addHighScore(int score, string name){
        for (int i = 0; i < highScores.Count; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i,score);
                highScoreNames.Insert(i, name);  
                if (highScores.Count > 10)
                {
                    highScores.RemoveAt(10);
                    highScoreNames.RemoveAt(10);
                }
                writePrefs(); 
                return;             
            }
        }
    }
	
    static void writePrefs(){
        for (int i = 0; i < highScores.Count; i++)
        {
            string highScoreKey = "highScore"+i.ToString();
            string highScoreNameKey = "highScoreName"+i.ToString();
            PlayerPrefs.SetInt(highScoreKey, highScores[i]);
            PlayerPrefs.SetString(highScoreNameKey, highScoreNames[i]);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
