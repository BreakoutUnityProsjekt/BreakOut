using UnityEngine;
using System.Collections;

public class HalfTheSize : MonoBehaviour {

	public static bool halfSize = false;

	void OnCollisionEnter(Collision col){
		GameManager.instance.clonePaddle.transform.localScale = new Vector3 (18f, 2.359376f, 2.076007f);
		halfSize = true;
	}
}
