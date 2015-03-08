using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	// Added to the cube at the bottom, calls on the lose life, which does the rest.
	// Its worth noting that  this object needs to be a trigger.
	void OnTriggerEnter(Collider col){
		GameManager.instance.LoseLife ();
	}
	
}
