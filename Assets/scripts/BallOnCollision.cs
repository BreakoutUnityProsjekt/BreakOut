using UnityEngine;
using System.Collections;

public class BallOnCollision : MonoBehaviour {

	public int collisionCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (collisionCount);
	}

	void OnCollisionEnter(Collision col){
		collisionCount++;
		if (collisionCount == 4) {
			Controller.instance.ballRigidbody.AddForce(1300, 1300, 0);
		}
		if (collisionCount == 12) {
			Controller.instance.ballRigidbody.AddForce(2900, 2900, 0);
		}
	}
}
