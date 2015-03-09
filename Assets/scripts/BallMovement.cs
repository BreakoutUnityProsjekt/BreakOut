using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public Rigidbody ballRidigBody;

	// Use this for initialization
	void Start () {
		ballRidigBody.AddForce (new Vector3 (1000f, 0f, 0f));
	}
}
