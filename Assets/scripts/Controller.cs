using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	
	public float ypos = -75;
	public float zpos = 0f;
	public float speed = 250f;
	public float xMaxPos = 134.3f;
	public float xOffset = 17f;
	public GameObject ballPrefab;
	public GameObject attachedBall = null;
	private GameObject ballClone;
	public GameObject deadZone;
	public Rigidbody ballRigidbody;
	public float ballspeed = 4000f;
	public static Controller instance;
	public float speedFactor = 0;
	public int outerEdge = 10;
	public int innerEdge = 6;
	
	// Use this for initialization
	void Start (){
		//Spawing the ball
		spawnBall ();
		instance = this; 
	}
	
	// Update is called once per frame
	void Update (){
		// Getting the input axis from user, transforming the x axis, based on speed times Time and Horizontal Axis.
		if (Input.GetAxis ("Horizontal") != 0) {
			transform.position = new Vector3 (transform.position.x + Input.GetAxis ("Horizontal") * speed * Time.deltaTime, ypos, zpos);

			// If the padde is reduced to half size, we need to change the xOffset so that it 
			// does not look wierd and paddle goes out of the map.
			if(PaddleSize.halfSize == true && !PowerUp.instance.biggerPaddle){
				xOffset = xOffset / 2 + 3;
				innerEdge = 1;
				outerEdge = 3;
			} 
			// Same if the paddle is bigger, also changing the edge where it changes the balls direction.
			else if(PowerUp.instance.biggerPaddle == true){
				xOffset = 24;
				outerEdge = 17;
				innerEdge = 9;
			} else {
				xOffset = 17f;
				innerEdge = 6;
				outerEdge = 10;
			}

			// Making sure the paddle does not moce further than the max posision of the pillars.
			if (transform.position.x < -xMaxPos + xOffset) {
				transform.position = new Vector3 (-xMaxPos + xOffset, ypos, zpos);
			} else if (transform.position.x > xMaxPos - xOffset) {
				transform.position = new Vector3 (xMaxPos - xOffset, ypos, zpos);
			}
		}

		// Making sure the ball is attached to the paddle at the start.
		if (attachedBall) {
			ballRigidbody = attachedBall.rigidbody;
			ballRigidbody.position = transform.position + new Vector3 (0f, 5.5f, 0f);

			// If "Jump" key is pressed, ball is released from paddle.
			if (Input.GetButtonDown ("Jump")) {
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce (0, ballspeed, 0);
				ballClone = attachedBall;
				attachedBall = null;
			}
						

		}


	}
	// Instatiating the ball into a variabel, so it can easily be removed later.
	void spawnBall ()
	{
		attachedBall = Instantiate (ballPrefab, transform.position + new Vector3 (0, 40, 0), Quaternion.identity) as GameObject;
	}

	//
	void OnCollisionEnter(Collision col){
		foreach(ContactPoint contact in  col.contacts){
			if(contact.thisCollider == collider){
				float ballangle = contact.point.x - transform.position.x;
				if(ballangle > outerEdge){
					// Creating a new vector when ball is colling with the outer edge of the paddle.
					ballRigidbody.velocity = new Vector3(56.569f + speedFactor + ballangle, 56.569f + speedFactor - ballangle, 0);

				} else if (ballangle < -outerEdge){
					// Adding speed factor to it so the magnitude of the vector wont change, also adding in the ballangle so that
					// It will go more to the sides the furter it lands on the paddle.
					ballRigidbody.velocity = new Vector3(-56.569f - speedFactor + ballangle, 56.569f + speedFactor + ballangle, 0);

				} else {
					// if the ball is traveling too much on the X axis, we want to send it up in the air again.
					if(ballRigidbody.velocity.y < 50){
						ballRigidbody.velocity = new Vector3(-40f - speedFactor, 69.29f + speedFactor, 0f);
					} else if(ballRigidbody.velocity.y > 140){
						ballRigidbody.velocity = new Vector3(40f + speedFactor, 69.29f + speedFactor, 0f); 
					}
				}
				// If ball is between middle and egde this vector will be added.
				if(ballangle > innerEdge && ballangle <= outerEdge){
					ballRigidbody.velocity = new Vector3(20.706f + speedFactor + ballangle, 77.274f + speedFactor - ballangle, 0);
				}
				if(ballangle < -innerEdge && ballangle >= -outerEdge){
					ballRigidbody.velocity = new Vector3(-20.706f - speedFactor + ballangle, 77.274f + speedFactor + ballangle, 0);

				}
			}
		}
		ballRigidbody.AddTorque(new Vector3(300, 300, 300));
	}

	// Simple method to destroy the cloned ball.
	public void DestroyBall(){
		Destroy (ballClone);
	}

}

