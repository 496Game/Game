using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyRaycast : MonoBehaviour {
	public AudioSource[] patternToPlay;
	public GameObject playButton;
	public char[] notes = new char[] {'d','a','b'} ;
	public int ap = 0 ; // array pointer
	public bool emWinCondition = false ; // the varable checks if you have won or not

	void Start() {
		patternToPlay = playButton.GetComponents<AudioSource> ();
		//patternToPlay [0].Play ();
		//patternToPlay [1].Play ();
		//patternToPlay [2].Play ();
		//patternToPlay [3].Play ();
		//patternToPlay [4].Play ();
	}


	void Update() {
		if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) {
					if (hit.transform.gameObject.layer != 8) {
						hit.transform.gameObject.GetComponent<AudioSource>().Play();

						// save the tag and compare it to the apropriete location in the notes array
						string currentNote = hit.transform.gameObject.tag ;

						if (currentNote == "a" || currentNote == "b" || currentNote == "c" || currentNote == "d" || currentNote == "e") {
							if (notes [ap].ToString () == currentNote) {
								print ("Correct");
								ap += 1;
								if (ap == notes.Length) {
									emWinCondition = true;
									GetComponent<GameControl>().EmilyGameComplete = true;
									PlayNotes ();
								}
							} else {
								print ("Bad");
								ap = 0;
							} // end if else
						} else if (currentNote == "tonePlayer") {
							print ("Going to play notes");
							PlayNotes ();

						}// end if else
					} // end if
				}
			} // end if
        } // end if

	} // end Update()


	void PlayNotes() {
			StartCoroutine ("theIEnumerator");
	} // end PlayNotes()

	IEnumerator theIEnumerator () {
		print ("You are doing the coroutine");

		char theNote ;

		for (int i = 0; i < notes.Length; i++) {
			// make a switch case statement that connects notes to possition of Audiosource Array
			theNote = notes[i] ;

			switch (theNote) {
			case 'a':
				patternToPlay [0].Play ();
				print ("a");
				break;

			case 'b':
				patternToPlay [1].Play ();
				Debug.Log ("b");
				break;

			case 'c':
				patternToPlay [2].Play ();
				Debug.Log ("c");
				break;

			case 'd':
				patternToPlay [3].Play ();
				Debug.Log ("d");
				break;

			case 'e':
				patternToPlay [4].Play ();
				Debug.Log ("e");
				break;

			default:
				continue;


			} // end switch case
			yield return new WaitForSeconds(1) ;
		} // end for

	}
}
