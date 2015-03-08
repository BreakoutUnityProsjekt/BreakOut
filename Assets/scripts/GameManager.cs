using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int life = 3;
	public int blocks = 148;
	public int score = 0;
	public int highScore = 0;
	public int restartDelay = 3;
	public Text livesText;
	public Text scoreText;
	public string highScoreKey = "HighScore";
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
		// Gets the highscore from PlayerPrefs.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
	}
	public void Setup(){
		// Sets up the paddle on its default posision.
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;

	}
	void Restart(){
		// Restarts the game automatic, when you die.
		PowerUp.instance.biggerPaddle = false;
		PaddleSize.instance.halfSize = false;
		Application.LoadLevel (1);
	}

	// Checks this every time block is destroyed and you lose a life.
	// If u won it takes you to the scorescreen, and if either life or blocks
	// is equal to zero, it will save the score if it was greater than previous.
	void WinOrLoseCheck(){
		if (blocks <= 0) {
			youWon.SetActive(true);
			Invoke("ScoreSceen", restartDelay);
		}
		if (life <= 0) {
			gameOver.SetActive(true);
			Invoke("Restart", restartDelay);
		}
		if (life <= 0 || blocks <= 0) {
			if(score>highScore){
				PlayerPrefs.SetInt(highScoreKey, score);
				PlayerPrefs.Save();
			}
		}
	}
	// Loads the ScoreScreen.
	void ScoreSceen(){
		PowerUp.instance.biggerPaddle = false;
		PaddleSize.instance.halfSize = false;
		Application.LoadLevel (2);
	}

	// When you lose a life, it prints the new life, destroys the paddle, and invokes the setup again.
	// allso destroys the ball, so we wont have extra balls taking performance.
	public void LoseLife(){
		life--;
		livesText.text = "Lives: " + life;
		Destroy (clonePaddle);
		Controller.instance.DestroyBall ();
		Invoke ("SetupPaddle", 3);
		PowerUp.instance.ResetPaddle ();
		WinOrLoseCheck ();
	}
	// Gains a life and updates the text.
	public void GainLife(){
		life++;
		livesText.text = "Lives: " + life;
	}

	// making sure the size modifying variables is set to false, since the paddle will be reset.
	void SetupPaddle(){
		PowerUp.instance.biggerPaddle = false;
		PaddleSize.instance.halfSize = false;
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}
	// When a blokc is destroyed, subtract from total blocks, and adds to the score.
	public void OnBlockDestroyed(){
		blocks--;
		score++; 
		scoreText.text = "Score: " + score;
		WinOrLoseCheck ();
	}


}
 