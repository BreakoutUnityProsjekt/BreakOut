using UnityEngine;
using System.Collections;

public class PaddleSize : MonoBehaviour {

	public bool halfSize = false;
	public static PaddleSize instance;

	void Start(){
		instance = this;
	}
	// Halving the size of the paddle, set it to a fixed amount so its more controllable, with the walls and the
	// Collision detection, also it does not trigger if you are under the effect off the powerup BiggerPaddle.
	void OnCollisionEnter(Collision col){
		if (PowerUp.instance.biggerPaddle == false) {
			GameManager.instance.clonePaddle.transform.localScale = new Vector3 (18f, 2.359376f, 2.076007f);
			halfSize = true;
		}
	}

}
