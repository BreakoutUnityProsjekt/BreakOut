using UnityEngine;
using System.Collections;

public class PaddleSize : MonoBehaviour {

	public static bool halfSize = false;
	public static PaddleSize instance;

	void Start(){
		instance = this;
	}

	void OnCollisionEnter(Collision col){
		GameManager.instance.clonePaddle.transform.localScale = new Vector3 (18f, 2.359376f, 2.076007f);
		halfSize = true;
	}

}
