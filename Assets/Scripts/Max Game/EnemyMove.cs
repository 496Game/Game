using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : movement {

    [SerializeField]
    private int[] moveArray = new int[10];

    public int number;

    protected int count = 0;



    //int layerMask = 1 << 8;

      //sets gameobject rigid body to RB
	// Use this for initialization
	void Start () {
        SetUp();

        /*moveArray[0] = 1;
        moveArray[1] = 1;
        moveArray[2] = 0;
        moveArray[3] = 3;
        moveArray[4] = 2;
        moveArray[5] = 1;
        moveArray[6] = 3;
        moveArray[7] = 0;
        moveArray[8] = 0;
        moveArray[9] = 2;*/
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
        int forever = 7 - count;
        if (forever < 0)
        {
            forever = forever * -1;
        }
        bool blocked = false;
		bool reset = false;

		if (onNegXChar) 
		{
			print ("dsfdsfasfdsaf");
			count = 3;
			reset = true;

		}
		if (onNegZChar) 
		{
			print ("dsfdsfasfdsaf");
			count = 0;
			reset = true;
		}
		if (onXChar) 
		{
			print ("dsfdsfasfdsaf");
			count = 2;
			reset = true;
		}
		if (onXChar) 
		{
			print ("dsfdsfasfdsaf");
			count = 1;
			reset = true;
		}
        switch(moveArray[count])
        {
            case 3:
				
                if(onNegZ)
                {
                    blocked = true;
                }
                    
                else
                    moveLeft();
                moveArray[forever] = Random.Range(0, 4);
                break;

            case 2:
                if (onX)
                {
                    blocked = true;
                }

                else
                    moveDown();
                moveArray[forever] = Random.Range(0, 4);
                break;

            case 1:
                if (onZ)
                {
                    blocked = true;
                }

                else
                    moveRight();
                moveArray[forever] = Random.Range(0, 4);
                break;

            case 0:
                if (onNegX)
                {
                    blocked = true;
                }

                else
                    moveUp();
                moveArray[forever] = Random.Range(0,4);
                break;

            default:
                Debug.Log("cant move");
                break;
        }
        if (((count+ 1) % 10) == 0)
            count = 0;

        else
            count++;
        if(blocked)
        {
            structureMove();
        }
		if (reset) 
		{
			man.reset = true;
		}
        
    }

}
