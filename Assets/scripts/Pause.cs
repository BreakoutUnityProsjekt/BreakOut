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

		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseGame = !pauseGame;

		}

		if (pauseGame == true) {

			Time.timeScale = 0;
			pauseGame = true;
			showText = true;
		}
		if (pauseGame == false) {
			Time.timeScale = 1;
			pauseGame = false;
			showText = false;
		}

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
