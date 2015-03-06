using UnityEngine;
using System.Collections;

public class Bounty : MonoBehaviour {

	public GameObject bountyBlock;
	public GameObject bricksPrefab;
	public Rigidbody block;
	public static Bounty spawn;

	void Start(){
		spawn = this;

	}
	public void spawnBlock(){
		bountyBlock = Instantiate(bricksPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
	}
}
