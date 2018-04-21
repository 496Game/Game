using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour {
	public GameObject Player;

	Animator anim; 						// animator of current lever or current light
	AudioSource audioS;					// declare audio source
	public GameObject[] lights = new GameObject[7]; // array of all the lights
	LightManipulation lm;				// declaration of current lightmanipulation script.
	public bool success = false;		// THIS IS THE SUCCESS CHECK - WHEN THE PUZZLE IS COMPLETE THIS WILL BE TRUE.

	// Use this for initialization
	void Start () {
		audioS = gameObject.GetComponent<AudioSource>(); // initialize audio source
	}
	
	// Update is called once per frame
	void Update () {
		//Player.GetComponent<GameControl>().NicoleGameComplete = success;
	}

	// Method:      PullTheLeverKronk
	// Parameter:   GameObject currLever - a reference to the lever
	//              which is being pulled
	// Return:      None, void.
	// Description: This function will access the animator of the
	//              lever that has been hit, and flip that animation.
	//              It will also play audio for the sound of the lever.
	public void PullTheLeverKronk(GameObject currLever) {
		// variable to hold animator
		anim = currLever.GetComponent<Animator> ();
		// variable to hold light manipulation script
		lm = currLever.GetComponent<LightManipulation>();

		// play audio
		audioS.time = 6.5f;
		audioS.Play ();

		// take the current status of the animation, and switch it.
		if (anim.GetBool ("flip")) 
			anim.SetBool ("flip", false);
		else 
			anim.SetBool ("flip", true);

		// flip the lights based on light manipulation
		lm.WrongLever(); 

		// loop through all of the lights to see if the level is complete
		success = Kuzco();
		Player.GetComponent<GameControl>().NicoleGameComplete = success;
		Player.GetComponent<GameControl>().CheckVictory();
	}

	// Method:      Kuzco
	// Parameter:   none
	// Return:      bool - a status check on whether or not the
	//              puzzle has been completed
	// Description: This function will loop through all of the lights
	//              and check to see which lights have been activated.
	//              If they have all been activated, it will return
	//              true and the puzzle will be completed.
	bool Kuzco() {
		for (int i = 0; i < lights.Length; i++) {
			// get reference to animator
			anim = lights[i].GetComponent<Animator>();

			if (!anim.GetBool ("switch")) {
				success = false;
				return false;
			}
		}

		return true;
	}
}
