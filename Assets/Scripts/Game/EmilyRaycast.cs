using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyRaycast : MonoBehaviour {
	public AudioSource[] patternToPlay;
	public GameObject playButton;

	public char[] notesOne = new char[] {'d','a','b'} ;
	public char[] notesTwo = new char[] {'a','c','e','b','e'} ;
	public char[] notesThr = new char[] {'b','d','d','a','c','e','b'} ;

	public int ap = 0 ; // array pointer

	//bools to test the win state
	public int gameNumber = 1 ;
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

						// save the tag and compare it to the apropriete location in the notes array
						string currentNote = hit.transform.gameObject.tag ;

						// check to see if it is a note
						if (currentNote == "a" || currentNote == "b" || currentNote == "c" || currentNote == "d" || currentNote == "e") {
							hit.transform.gameObject.GetComponent<AudioSource>().Play();


							switch (gameNumber) {

							case 1:
								// check to see if the note is correct
								if (notesOne [ap].ToString () == currentNote) {
									ap += 1;
									// check to see if you reached the end of the notes
									if (ap == notesOne.Length) {
										ap = 0;
										gameNumber++;
										PlayNotes ();
									}
									// if its wrong, it resets you to the beginning your current note pattern
								} else {
									print ("Bad");
									ap = 0;
								} // end if else
								break;

							case 2:
								// check to see if the note is correct
								if (notesTwo [ap].ToString () == currentNote) {
									ap += 1;
									// check to see if you reached the end of the notes
									if (ap == notesTwo.Length) {
										ap = 0;
										gameNumber++;
										PlayNotes ();
									}
									// if its wrong, it resets you to the beginning your current note pattern
								} else {
									print ("Bad");
									ap = 0;
								} // end if else
								break;

							case 3:
								// check to see if the note is correct
								if (notesThr [ap].ToString () == currentNote) {
									ap += 1;
									// check to see if you reached the end of the notes
									if (ap == notesThr.Length) {
										ap = 0;
										gameNumber++;
										PlayNotes ();
									}
									// if its wrong, it resets you to the beginning your current note pattern
								} else {
									print ("Bad");
									ap = 0;
								} // end if else
								break;

							default:
								break;

							} // end switch case

						// Checks to see if it is the button to play the string of notes back to you
						} else if (currentNote == "tonePlayer") {
							print ("Going to play notes");
							PlayNotes ();

						}// end if else
					} // end if
				} // end if
			} // end if
        } // end if

		// check to see if the player has won all three games
		if (gameNumber >3) {
			emWinCondition = true;

			GetComponent<GameControl>().EmilyGameComplete = true;
			GetComponent<GameControl>().CheckVictory();
		}

	} // end Update()



	/*
	 * The PlayNotes function and the theIEnumerator function
	 * Play the current string of notes back to you if you
	 * press the button to hear the notes 
	*/
	void PlayNotes() {
			StartCoroutine ("theIEnumerator");
	} // end PlayNotes()

	IEnumerator theIEnumerator () {
		print ("You are doing the coroutine");

		char theNote ;

		yield return new WaitForSeconds(1) ;

		if (gameNumber == 1) {
			for (int i = 0; i < notesOne.Length; i++) {
				// make a switch case statement that connects notes to possition of Audiosource Array

				theNote = notesOne[i] ;


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
		} else if (gameNumber == 2) {
			for (int i = 0; i < notesTwo.Length; i++) {
				// make a switch case statement that connects notes to possition of Audiosource Array

				theNote = notesTwo[i] ;


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
		} else if (gameNumber == 3) {
			for (int i = 0; i < notesThr.Length; i++) {
				// make a switch case statement that connects notes to possition of Audiosource Array

				theNote = notesThr[i] ;


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
		} else {
			
		} // end if else
	} // end theIEnumerator
}
