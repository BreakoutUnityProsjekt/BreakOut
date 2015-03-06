using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;
	private GameObject particle = null;
	private float rand;
	public static Bricks instance;

	void Start(){
		instance = this;
	}


	void OnCollisionEnter(Collision other){
		// animating the particles when the block is destroyed
		particle = (GameObject) Instantiate (brickParticle, transform.position, Quaternion.identity);

		// PowerUp 10%
		rand = Random.Range (0,100);
		if (rand < 10) {
			PowerUp.instance.Power();
		}

		// Simple way of adding more score to the diffrent colored bricks
		if(this.name == "greenBrick"){
			GameManager.instance.score += 1;
		}
		if (this.name == "yellowBrick") {
			GameManager.instance.score += 2;
		}
		if (this.name == "brownBrick") {
			GameManager.instance.score += 3;		
		}
		if (this.name == "orangeBrick") {
			GameManager.instance.score += 4;		
		}
		if (this.name == "redBrick") {
			GameManager.instance.score += 5;		
		}

		// Adds more speed to the ball from these bricks
		if (this.name == "purpleBrick") {
			GameManager.instance.score += 6;
			Controller.instance.speedFactor += 2;
		}
		if (this.name == "deepblueBrick") {
			GameManager.instance.score += 7;
			Controller.instance.speedFactor += 4;
		}

		//Destroying blocks and particles
		GameManager.instance.OnBlockDestroyed ();
		Destroy (gameObject);
		Destroy (particle, 5f);
	}
}
