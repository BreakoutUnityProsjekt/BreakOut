using UnityEngine;
using System.Collections;

public class Explosion1 : MonoBehaviour {

	public GameObject Explosion;
	public GameObject explosionPrefab;
	public GameObject Ball;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Explosion = Instantiate (explosionPrefab, Ball.transform.position, Quaternion.identity) as GameObject;

	}

	void OnCollisionEnter(Collision col){
		Explosion = Instantiate (explosionPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
	}
}
