using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : movement {

	public bool left;
	public bool right = false;
	public bool up;
	public bool down;

	public bool triggered = false;
	// Use this for initialization
	void Start () {
		SetUp();
		//StartCoroutine ("Right");
	}

	// Update is called once per frame
	void Update () {

		Raycasting ();
		if (triggered == false) {
			
			if (!onNegZ && left && Input.GetMouseButtonUp (0)) {
				moveLeft ();
				triggered = true;
				man.StartCoroutine ("MoveOrder");
				left = false;
			} 
			
			if (!onZ && right && Input.GetMouseButtonUp (0)) {
				moveRight ();
				triggered = true;
				man.StartCoroutine ("MoveOrder");
				right = false;
			}
			

			if (up) {
				if (!onNegX && up && Input.GetMouseButtonUp (0)) {
					moveUp ();
					triggered = true;
					man.StartCoroutine ("MoveOrder");
					up = false;
				} 


			}

			if (down) {
				if (!onX && down && Input.GetMouseButtonUp (0)) {
					moveDown ();
					triggered = true;
					man.StartCoroutine ("MoveOrder");
					down = false;
				} 

			}

		}
	}
}

