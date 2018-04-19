using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : movement {

	public bool left;
	public bool right;
	public bool up;
	public bool down;

	bool triggered = false;
	// Use this for initialization
	void Start () {
		SetUp();
		StartCoroutine ("Right");
	}

	// Update is called once per frame
	void Update () {

		Raycasting ();
		if (left)
		{
			if (!onNegZ) {
				moveLeft ();
				man.StartCoroutine ("MoveOrder");
			} else {
			}

			left = false;

		}


		if (up)
		{
			if (!onNegX) {
				moveUp ();
				man.StartCoroutine ("MoveOrder");
			} else {
			}


		}

		if (down)
		{
			if (!onX) {
				moveDown ();
				man.StartCoroutine ("MoveOrder");
			} else {
			}

		}


	}

	IEnumerator Right()
	{
		while (!triggered) {
			if (right) {
				right = false;
				if (!onZ) {
					moveRight ();
					man.StartCoroutine ("MoveOrder");
					StartCoroutine ("Right");

				} else {
				}
				print ("run");

			}
		}
		return null;
	}


}
