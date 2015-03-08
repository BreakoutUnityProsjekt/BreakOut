using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour {


	public int highScore = 0;
	string highScoreKey = "HighScore";
	public Text score;

	// Prints the score to the screen from the player prefs,
	// I get an NullReference Exception here, Not sure why.
	void Start(){
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		score.text = "HighScore: " + highScore;
	}

}
