using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicoleRaycast : MonoBehaviour {

	// cool down timer for the raycast hit.
	float time = 0;

	// LeverManager script access
	public LeverManager lm;


	void Update() {
		// add to timer
		time += Time.deltaTime;

		// if mouse is clicked
		if (Input.GetMouseButtonDown(0)) {
			// variables hold object that hits raycast
            RaycastHit hit;		
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ray cast off of mouse pos
            if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) { // if there is a rigid body
					// check what was hit if the timer allows
					if (time >= 1) {
						ObjectHit (hit);
						time = 0;
					}
				}
			}
        }

	}


	// Method:      ObjectHit
	// Parameter:   RaycastHit obj: the object that the raycast
	//              has hit.
	// Return:      None, void.
	// Description: This function will access whatever object the ray
	//              has hit, and will check to see if that object
	//              is a lever. If it is a lever, it will access the lever
	//              and relevant lights to switch them on/off.
	void ObjectHit(RaycastHit obj) {
		// check if the object is a lever
		if (obj.collider.CompareTag ("lever")) {
			// if the object is a lever, pull the lever
			lm.PullTheLeverKronk (obj.collider.gameObject);
		}
	}

}