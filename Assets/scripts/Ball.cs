using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public int collisions = 0;
	public Rigidbody ballRigidbody;
	public float forceAmount = 1000f;
	
	void OnCollisionEnter(Collision col){
		collisions++;
		if (collisions == 4) {
			Controller.instance.speedFactor = 10;
		}
		if (collisions == 12) {
			Controller.instance.speedFactor = 20;
		}
	}

}
