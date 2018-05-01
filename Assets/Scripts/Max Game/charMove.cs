using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : movement {

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
		SetUp();
		//StartCoroutine ("Right");

	}

	// Update is called once per frame
	void Update () {

		if (!onNegZ) {
			leftButton.material.color = Color.green;
		} else {
			leftButton.GetComponent<Renderer>().material.color = Color.red;
		}

		if (!onZ) {
			rightButton.material.color = Color.green;
		} else {
			rightButton.GetComponent<Renderer>().material.color = Color.red;
		}

		if (!onNegX) {
			upButton.material.color = Color.green;
		} else {
			upButton.GetComponent<Renderer>().material.color = Color.red;
		}

		if (!onX) {
			downButton.material.color = Color.green;
		} else {
			downButton.GetComponent<Renderer>().material.color = Color.red;
		}

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

