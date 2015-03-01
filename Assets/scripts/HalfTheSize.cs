using UnityEngine;
using System.Collections;

public class HalfTheSize : MonoBehaviour {

	public static bool halfSize = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		GameManager.instance.clonePaddle.transform.localScale = new Vector3 (18f, 2.359376f, 2.076007f);
		halfSize = true;
	}
}
