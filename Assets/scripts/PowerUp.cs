using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

	private float rand;
	public GameObject extraLifeText;
	public GameObject biggerPaddleText;
	public GameObject dubbleScore;
	public static PowerUp instance;

	public bool biggerPaddle = false;

	
	void Start(){
		instance = this;
	}
	
	public void ExtraLife(){
		GameManager.instance.GainLife();
		extraLifeText.SetActive (true);
		Invoke ("ClearText", 5);
	}
	public void BiggerPaddle(){
		GameManager.instance.clonePaddle.transform.localScale = new Vector3 (50f, 2.359376f, 2.076007f);
		biggerPaddle = true;
		biggerPaddleText.SetActive (true);
		Invoke ("ClearText", 5);
		Invoke ("ResetPaddle", 30);

	}
	public void ClearText(){
		biggerPaddleText.SetActive (false);
		extraLifeText.SetActive (false);
		dubbleScore.SetActive (false);
	}

	public void ResetPaddle(){
		if (GameManager.instance.clonePaddle != null && !PaddleSize.halfSize) {
			GameManager.instance.clonePaddle.transform.localScale = new Vector3 (36f, 2.359376f, 2.076007f);

		} else if (GameManager.instance.clonePaddle != null && PaddleSize.halfSize) {
			GameManager.instance.clonePaddle.transform.localScale = new Vector3 (18f, 2.359376f, 2.076007f);

		}
		biggerPaddle = false;
	}

	public void DubbleScore(){
		GameManager.instance.score *= 2;
		dubbleScore.SetActive (true);
		Invoke ("ClearText", 5);
	}

	public void Power(){
		rand = Random.Range (0, 3);

		if (rand == 0) {
			ExtraLife ();
		} else if (rand == 1) {
			BiggerPaddle ();
		} else if (rand == 2) {
			DubbleScore();
		} else if (rand == 3) {
			Debug.Log ("It works");
		}


	}
}
