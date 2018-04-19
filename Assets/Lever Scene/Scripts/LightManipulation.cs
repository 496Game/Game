using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManipulation : MonoBehaviour {

	public GameObject[] lights = new GameObject[4]; // the lights attached to this lever
	Animator anim; // the animator attached to the current light

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Method:      WrongLever
	// Parameter:   None
	// Return:      None, void.
	// Description: This function will loop through all of the 
	//              lights attached to this particular lever,
	//              and will switch the lights accordingly.
	public void WrongLever() {
		// loop through all of the lights
		for (int i = 0; i < lights.Length; i++) {
			if (lights != null) {
				// get a reference to the lights' animator
				anim = lights[i].GetComponent<Animator>();

				if (anim.GetBool ("switch")) {
					anim.SetBool ("switch", false);
				} else {
					anim.SetBool ("switch", true);
				}
			}
		}
	}
}
