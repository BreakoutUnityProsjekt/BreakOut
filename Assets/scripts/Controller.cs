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
	public GameObject extraBall;
	public GameObject extraBallPrefab;
	private GameObject ballClone;
	public bool extraBallBool = false;
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
		if (Input.GetAxis ("Horizontal") != 0) {
			transform.position = new Vector3 (transform.position.x + Input.GetAxis ("Horizontal") * speed * Time.deltaTime, ypos, zpos);

			if(HalfTheSize.halfSize == true){
				xOffset = xOffset / 2 + 3;
				innerEdge = 2;
				outerEdge = 5;
			} else {
				xOffset = 17f;
				innerEdge = 6;
				outerEdge = 10;
			}


				if (transform.position.x < -xMaxPos + xOffset) {
					transform.position = new Vector3 (-xMaxPos + xOffset, ypos, zpos);
					} else if (transform.position.x > xMaxPos - xOffset) {
						transform.position = new Vector3 (xMaxPos - xOffset, ypos, zpos);
					}
				}
			if (attachedBall) {
				ballRigidbody = attachedBall.rigidbody;
				ballRigidbody.position = transform.position + new Vector3 (0f, 5.5f, 0f);

			if (Input.GetButtonDown ("Jump")) {
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce (0, ballspeed, 0);
				ballClone = attachedBall;
				attachedBall = null;
			}
						

		}
		if(Input.GetKey(KeyCode.Q) && !extraBallBool){

			extraBallBool = true;
			extraBall = Instantiate (extraBallPrefab, transform.position + new Vector3 (0, 40, 0), Quaternion.identity) as GameObject;

		}

	}

	void spawnBall ()
	{
		attachedBall = Instantiate (ballPrefab, transform.position + new Vector3 (0, 40, 0), Quaternion.identity) as GameObject;
	}
	
	void OnCollisionEnter(Collision col){
		foreach(ContactPoint contact in  col.contacts){
			if(contact.thisCollider == collider){
				float ballangle = contact.point.x - transform.position.x;
				if(ballangle > outerEdge){
					//ballRigidbody.AddTorque(new Vector3(ballRigidbody.velocity.x * 1.5f, ballRigidbody.velocity.y, ballRigidbody.velocity.z));
					ballRigidbody.velocity = new Vector3(56.569f + speedFactor, 56.569f + speedFactor, 0);

				} else if (ballangle < -outerEdge){
				
					//ballRigidbody.AddTorque(new Vector3(ballRigidbody.velocity.x * 1.5f, ballRigidbody.velocity.y, ballRigidbody.velocity.z));
					ballRigidbody.velocity = new Vector3(-56.569f - speedFactor, 56.569f + speedFactor, 0);

				} else {
					if(ballRigidbody.velocity.y < 50){
						ballRigidbody.velocity = new Vector3(-40f - speedFactor, 69.29f + speedFactor, 0f);
					} else if(ballRigidbody.velocity.y > 140){
						ballRigidbody.velocity = new Vector3(40f + speedFactor, 69.29f + speedFactor, 0f); 
					}
				}
				if(ballangle > innerEdge && ballangle <= outerEdge){
					ballRigidbody.velocity = new Vector3(20.706f + speedFactor, 77.274f + speedFactor, 0);
				}
				if(ballangle < -innerEdge && ballangle >= -outerEdge){
					ballRigidbody.velocity = new Vector3(-20.706f - speedFactor, 77.274f + speedFactor, 0);

				}
			}
		}


	}
	


	public void DestroyBall(){
		Destroy (ballClone);
	}

}

