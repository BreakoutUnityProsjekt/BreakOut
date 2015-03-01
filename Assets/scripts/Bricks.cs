using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;
	private GameObject particle = null;


	void OnCollisionEnter(Collision other){
		particle = (GameObject) Instantiate (brickParticle, transform.position, Quaternion.identity);
		if (this.name == "redBrick") {
			GameManager.instance.score += 4;
		}
		if (this.name == "blueBrick") {
			GameManager.instance.score += 9;		
		}
		if(this.name == "greenBrick"){
			GameManager.instance.score += 14;
		}
		GameManager.instance.OnBlockDestroyed ();
		Destroy (gameObject);
		Destroy (particle, 5f);
	}

}
