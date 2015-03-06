using UnityEngine;
using System.Collections;

public class StartBallMovment : MonoBehaviour{

	public Rigidbody ballRidigBody; 

	// Use this for initialization
	void Start () {
		ballRidigBody.AddForce(new Vector3(10000f,1000f,0f));
	}	
}
