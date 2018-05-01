using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

	public GameObject board;  //board that characters are moving on

	[SerializeField]
	public float moveX = 0;  //length of character movement

	[SerializeField]
	public float moveZ = 0;    //width of character movement

	protected Rigidbody RB;   //declares rigidbody

	public bool onX; //checks on x axis positive

	public bool onNegX;

	public bool onZ; //checks on z axis

	public bool onNegZ;

	protected bool onXChar; //checks on x axis positive

	protected bool onNegXChar;

	protected bool onZChar; //checks on z axis

	protected bool onNegZChar;

	protected manager man;
	// Use this for initialization

	void Start()
	{

	}

	protected void SetUp()
	{
		moveX = (board.GetComponent<Collider>().bounds.size.x) / 8; //sets move length
		moveZ = (board.GetComponent<Collider>().bounds.size.z) / 8; //sets move width
		RB = gameObject.GetComponent<Rigidbody>();  //sets gameobject rigid body to RB 
		man = GameObject.FindGameObjectWithTag ("manager").GetComponent<manager>();

	}

	//raycast method that checks the four squares surrounding the piece

	public void Raycasting()
	{
		RaycastHit hit;
		onX = Physics.Raycast(RB.transform.position, RB.transform.right,  out hit, (1))&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");
		onNegX = Physics.Raycast(RB.transform.position, (RB.transform.right*-1),  out hit, (1))&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");
		onZ = Physics.Raycast(RB.transform.position, RB.transform.forward,out hit, (1))&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");
			onNegZ = Physics.Raycast(RB.transform.position, (RB.transform.forward*-1), out hit, (1))&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");

			onXChar = Physics.Raycast(RB.transform.position, RB.transform.right, out hit, 1) && hit.transform.tag == "player";
			onNegXChar = Physics.Raycast(RB.transform.position,(RB.transform.right*-1), out hit, (1))&& hit.transform.tag == "player";
			onZChar = Physics.Raycast(RB.transform.position, RB.transform.forward, out hit, (1))&& hit.transform.tag == "player";
			onNegZChar = Physics.Raycast(RB.transform.position, (RB.transform.forward*-1), out hit, (1))&& hit.transform.tag == "player";

		Debug.DrawRay(RB.transform.position, RB.transform.right * 1, Color.red);

		Debug.DrawRay(RB.transform.position,(RB.transform.right*-1) * 1, Color.red);

		Debug.DrawRay(RB.transform.position,  RB.transform.forward * 1, Color.red);

		Debug.DrawRay(RB.transform.position, (RB.transform.forward*-1) * 1, Color.red);
	}



	public void moveRight()
	{
		RB.transform.position += (RB.transform.forward);
		//RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y, RB.transform.position.z + moveZ);
	}

	public void moveLeft()
	{
		RB.transform.position += (RB.transform.forward * -1);
		// RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y, RB.transform.position.z - moveZ);
	}

	public void moveUp()
	{
		
		RB.transform.position += (RB.transform.right*-1);
		//RB.transform.position = new Vector3(RB.transform.position.x - moveX, RB.transform.position.y, RB.transform.position.z);
	}

	public void moveDown()
	{
		RB.transform.position += RB.transform.right;
		// RB.transform.position = new Vector3(RB.transform.position.x + moveX, RB.transform.position.y, RB.transform.position.z);
	}
}
