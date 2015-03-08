using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	// Loads level 1 which is the Main Level scene.
	public void LoadScene(){
		Application.LoadLevel (1);

	}

	// Exits the game when its build as a runnable .exe or whatever.
	public void ExitGame(){
		Application.Quit ();
	}

}
