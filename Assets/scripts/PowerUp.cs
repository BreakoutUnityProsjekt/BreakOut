using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

	private float rand;
	public GameObject extraLifeText;
	public GameObject biggerPaddleText;
	public GameObject dubbleScore;
	public bool biggerPaddle = false;
	public static PowerUp instance;
	
	void Start(){
		instance = this;
	}
	// Calls the gain life method and activates the text.
	public void ExtraLife(){
		GameManager.instance.GainLife();
		extraLifeText.SetActive (true);
		Invoke ("ClearText", 5);
	}
	// Transforming the paddle and making sure that a bool is set to true, so it can change the offsets
	// for the wall collision.
	public void BiggerPaddle(){
		GameManager.instance.clonePaddle.transform.localScale = new Vector3 (50f, 2.359376f, 2.076007f);
		biggerPaddle = true;
		biggerPaddleText.SetActive (true);
		Invoke ("ClearText", 5);
		Invoke ("ResetPaddle", 30);

	}
	// Cheap method to clear all text. Since it will not likely be 2 off them on the screen at the same
	// time, and even if there is its not that bad. 
	public void ClearText(){
		biggerPaddleText.SetActive (false);
		extraLifeText.SetActive (false);
		dubbleScore.SetActive (false);
	}

	// Resets the size of the paddle after the powerup, if the paddle was small, it will return small again.
	// same if it was normal.
	public void ResetPaddle(){
		if (GameManager.instance.clonePaddle != null && !PaddleSize.halfSize) {
			GameManager.instance.clonePaddle.transform.localScale = new Vector3 (36f, 2.359376f, 2.076007f);

		} else if (GameManager.instance.clonePaddle != null && PaddleSize.halfSize) {
			GameManager.instance.clonePaddle.transform.localScale = new Vector3 (18f, 2.359376f, 2.076007f);

		}
		biggerPaddle = false;
	}
	// Simple powerup to dubble the score, adds some RNG so people will try to replay the game, 
	// Its a fun factor, someone thinks it cool other dont. We chose to have it.
	public void DubbleScore(){
		GameManager.instance.score *= 2;
		dubbleScore.SetActive (true);
		Invoke ("ClearText", 5);
	}
	// Chooses randomly from 0-2 a power.
	public void Power(){
		rand = Random.Range (0, 3);

		if (rand == 0) {
			ExtraLife ();
		} else if (rand == 1) {
			BiggerPaddle ();
		} else if (rand == 2) {
			DubbleScore();
		} 

	}
}
