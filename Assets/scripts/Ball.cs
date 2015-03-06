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
			Bounty.spawn.spawnBlock();
		}
		if (collisions == 12) {
			Controller.instance.speedFactor = 20;
			Bounty.spawn.spawnBlock();
		}
	}

}
