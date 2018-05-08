using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : movement {

	[SerializeField]
	private int[] moveArray = new int[10];

	public int number;

	protected int count = 0;

	public Transform charPos;

	float moveDirX;
	float moveDirZ;




	//int layerMask = 1 << 8;

	//sets gameobject rigid body to RB
	// Use this for initialization
	void Start () {
		SetUp();

		moveArray[0] = 1;
        moveArray[1] = 1;
        moveArray[2] = 0;
        moveArray[3] = 3;
        moveArray[4] = 2;
        moveArray[5] = 1;
        moveArray[6] = 3;
        moveArray[7] = 0;
        moveArray[8] = 0;
        moveArray[9] = 2;
	}

	// Update is called once per frame
	void Update () {

		/* if(Input.GetKeyDown(KeyCode.Space))
        {
            structureMove();
            
        }*/

		Raycasting();


	}



	public void structureMove()
	{
        //sets char pos
		charPos = GameObject.FindGameObjectWithTag ("player").GetComponent<Transform>();

        //allows enemy to move forever and sets bools to false
        int forever = 7 - count;
        if (forever < 0)
        {
            forever = forever * -1;
        }
        bool blocked = false;
        bool reset = false;

        //declares array and sets direction to random number
        int[] closer = new int[2];
        int[] farther = new int[2];
        int direction = Random.Range(0, 5);
        int choice = Random.Range(0, 2);
			
        //divides x positions into two arrays
		if (charPos.position.x > gameObject.transform.position.x) 
		{
            closer[0] = 1;
            farther[0] = 3;
		}
        else
        {
            closer[0] = 3;
            farther[0] = 1;
        }

        //divides y into arrays
        if (charPos.position.y > gameObject.transform.position.y) 
		{
            closer[1] = 0;
            farther[1] = 2;
        }
           else
		{
            closer[1] = 2;
            farther[1] = 0;

        }


        //slecects number from one of the two arrays and assigns it to count
        if (direction <= 3)
        {
            count = closer[choice];
        }
        else
        {
            count = farther[choice];
        }

        //checks if player is nearby.  if true moves enemy on top of them
        if (onNegXChar) 
		{			
			count = 3;
			reset = true;
		}
		if (onNegZChar) 
		{
			count = 0;
			reset = true;
		}
		if (onXChar) 
		{
			count = 2;
			reset = true;
		}
		if (onXChar) 
		{
			count = 1;
			reset = true;
		}

        //uses variable count to call 4 cases to decide on movement direction
		switch(count)
		{
		case 3:

			if(onNegZ)
			{
				blocked = true;
			}

			else
				moveLeft();
			break;

		case 2:
			if (onX)
			{
				blocked = true;
			}

			else
				moveDown();
			break;

		case 1:
			if (onZ)
			{
				blocked = true;
			}

			else
				moveRight();
			break;

		case 0:
			if (onNegX) {
				blocked = true;
			} else
				moveUp();
			break;

		default:
			break;
		}

        //if enemy cant move calls function again
		if(blocked)
		{
			structureMove();
		}

        //if reset is true resets positions
		if (reset) 
		{
			man.reset = true;
		}

	}

}
