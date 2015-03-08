using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	private bool pauseGame = false;
	private bool showText = false;
	public GameObject pausedGame;
	public GameObject exitGame;
	public GameObject restartGame;

	void Update(){

		// Very smary way to unpause and pase with the same key, and little code.
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseGame = !pauseGame;

		}
		// Pauses the game.
		if (pauseGame == true) {

			Time.timeScale = 0;
			pauseGame = true;
			showText = true;
		}

		// Resumes the game.
		if (pauseGame == false) {
			Time.timeScale = 1;
			pauseGame = false;
			showText = false;
		}

		// Shows the approptiate text and buttons, when its paused.
		if (showText == true) {
			exitGame.SetActive(true);
			restartGame.SetActive(true);
			pausedGame.SetActive(true);
		} else{
			exitGame.SetActive(false);
			restartGame.SetActive(false);
			pausedGame.SetActive(false);
		}


	}

}
