using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : movement {


	// Use this for initialization
	void Start () {
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {
        



    }

	IEnumerator PlayerMove()
	{
		
		bool moved = false;
		if (Input.GetKeyDown(KeyCode.A))
		{
			moveLeft();
			moved = true;

		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			moveRight();
			moved = true;
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			moveUp();
			moved = true;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			moveDown();
			moved = true;
		}

		if (moved) 
		{
			man.StartCoroutine("MoveOrder");
		}
			

		return null;
	}


}
