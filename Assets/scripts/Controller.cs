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
		//Debug.Log (ballRigidbody.velocity);

	}

	void spawnBall ()
	{
		attachedBall = Instantiate (ballPrefab, transform.position + new Vector3 (0, 40, 0), Quaternion.identity) as GameObject;
	}
	
	void OnCollisionEnter(Collision col){
		foreach(ContactPoint contact in  col.contacts){
			if(contact.thisCollider == collider){
				float ballangle = contact.point.x - transform.position.x;
				if(ballangle > 8){
					ballRigidbody.AddTorque(new Vector3(ballRigidbody.velocity.x * 1.5f, ballRigidbody.velocity.y, ballRigidbody.velocity.z));
					ballRigidbody.velocity = new Vector3(56.569f + speedFactor, 56.569f + speedFactor, 0);
					Debug.Log(ballRigidbody.velocity);
					
				} else if (ballangle < -8){
				
					ballRigidbody.AddTorque(new Vector3(ballRigidbody.velocity.x * 1.5f, ballRigidbody.velocity.y, ballRigidbody.velocity.z));
					//ballRigidbody.velocity = Vector3.Reflect (new Vector3(ballRigidbody.velocity.x * 2,ballRigidbody.velocity.y / 2, 0), ballRigidbody.velocity.normalized);e
					ballRigidbody.velocity = new Vector3(-56.569f - speedFactor, 56.569f + speedFactor, 0);

				} else {
					//ballRigidbody.velocity = Vector3.Reflect (new Vector3(ballRigidbody.velocity.x * 2,ballRigidbody.velocity.y / 2, 0), ballRigidbody.velocity.normalized);
					//ballRigidbody.velocity = new Vector3(ballRigidbody.velocity.x, ballRigidbody.velocity.y, 0);
					if(ballRigidbody.velocity.y < 50){
						ballRigidbody.velocity = new Vector3(-40f - speedFactor, 69.29f + speedFactor, 0f);
					} else if(ballRigidbody.velocity.y > 140){
						ballRigidbody.velocity = new Vector3(40f + speedFactor, 69.29f + speedFactor, 0f); 
					}
				}
			}
		}


	}
	


	public void DestroyBall(){
		Destroy (ballClone);
	}

}

