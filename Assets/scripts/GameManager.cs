using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int life = 3;
	public int blocks = 144;
	public int score = 0;
	public int restartDelay = 3;
	public int highScore = 0;
	public Text livesText;
	public Text scoreText;
	public GameObject gameOver;
	public GameObject hScore;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject clonePaddle;
	public GameObject deathParticles;
	public static GameManager instance;
	public Rigidbody ballRigidbody;


	// Use this for initialization
	void Start () {
		instance = this;
		Setup ();
	}
	public void Setup(){
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;

	}
	void Restart(){
		Application.LoadLevel (1);
		PaddleSize.halfSize = false;
	}
	
	void WinOrLoseCheck(){
		if (blocks <= 0) {
			youWon.SetActive(true);
			Invoke("Restart", restartDelay);
		}
		if (life <= 0) {
			if (score > getHighScore ()) {
				highScore += score;
				hScore.SetActive (true);
				setHighScore ();
			}
			gameOver.SetActive(true);
			Invoke("Restart", restartDelay);
		}
	}

	void setHighScore()
	{
		PlayerPrefs.SetInt ("Highscore: ", highScore);
	}

	public int getHighScore()
	{
		highScore = PlayerPrefs.GetInt ("Highscore: ", 0);
		return highScore;
	}
	
	public void LoseLife(){
		life--;
		livesText.text = "Lives: " + life;
		Destroy (clonePaddle);
		Controller.instance.DestroyBall ();
		Invoke ("SetupPaddle", 3);
		WinOrLoseCheck ();
	}

	public void GainLife(){
		life++;
	}

	void SetupPaddle(){
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		PaddleSize.halfSize = false;
	}
	
	public void OnBlockDestroyed(){
		blocks--;
		score++; 
		scoreText.text = "Score: " + score;
		WinOrLoseCheck ();
	}
	
}
 