using UnityEngine;
using System.Collections;

public class BrickTest : MonoBehaviour {

	public GameObject brickPrefab;
	public GameObject block;
	public Rigidbody rblock;

	// Use this for initialization
	void Start () {
		block = Instantiate (brickPrefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
		rblock = block.rigidbody;
	}
}
