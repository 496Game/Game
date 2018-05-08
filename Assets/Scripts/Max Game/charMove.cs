using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : movement {
    //declares variables
	public bool left;
	public bool right = false;
	public bool up;
	public bool down;

	public Renderer leftButton;
	public Renderer rightButton;
	public Renderer upButton;
	public Renderer downButton;

	public bool triggered = false;
	// Use this for initialization
	void Start () {
        //calls setup inherited from movement class
		SetUp();
	}

	// Update is called once per frame
	void Update () {
        //renders button colors based on players ability to move each direction
		if (!onNegZ) {
			leftButton.material.color = Color.yellow;
		} else {
			leftButton.GetComponent<Renderer>().material.color = Color.red;
		}

		if (!onZ) {
			rightButton.material.color = Color.yellow;
		} else {
			rightButton.GetComponent<Renderer>().material.color = Color.red;
		}

		if (!onNegX) {
			upButton.material.color = Color.yellow;
		} else {
			upButton.GetComponent<Renderer>().material.color = Color.red;
		}

		if (!onX) {
			downButton.material.color = Color.yellow;
		} else {
			downButton.GetComponent<Renderer>().material.color = Color.red;
		}
        //calls raycast funtion from move script
		Raycasting ();
        //checks if triggered is false.  Used to make sure player can't spam movement
		if (triggered == false) {
			
            //button presses
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
			


				if (!onNegX && up && Input.GetMouseButtonUp (0)) {
					moveUp ();
					triggered = true;
					man.StartCoroutine ("MoveOrder");
					up = false;
				} 

				if (!onX && down && Input.GetMouseButtonUp (0)) {
					moveDown ();
					triggered = true;
					man.StartCoroutine ("MoveOrder");
					down = false;
				} 

		}
	}
}

