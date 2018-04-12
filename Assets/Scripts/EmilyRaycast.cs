using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyRaycast : MonoBehaviour {

	public char[] notes = new char[] {'d','a','b'} ;
	public int ap = 0 ; // array pointer
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) {
					hit.transform.gameObject.GetComponent<AudioSource>().Play();

					// save the tag and compare it to the apropriete location in the notes array
					string currentNote = hit.transform.gameObject.tag ;

					if (notes [ap].ToString () == currentNote) {
						print ("Correct");
						ap++;
					} else {
						print ("Bad");
						ap = 0;
					} // end if else
				} // end if
			} // end if
        } // end if
	} // end Update()
}
