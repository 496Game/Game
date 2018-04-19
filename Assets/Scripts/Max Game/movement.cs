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

    protected bool onX; //checks on x axis positive

    protected bool onNegX;

    protected bool onZ; //checks on z axis

    protected bool onNegZ;

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

    protected void Raycasting()
    {
		RaycastHit hit;
		onZ = Physics.Raycast(RB.transform.position, new Vector3(0, 0, 1),  out hit, moveZ)&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");
		onNegZ = Physics.Raycast(RB.transform.position, new Vector3(0, 0, -1), out hit, moveZ)&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");
		onX = Physics.Raycast(RB.transform.position, new Vector3(1, 0, 0),out hit, moveX)&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");
		onNegX = Physics.Raycast(RB.transform.position, new Vector3(-1, 0, 0), out hit, moveX)&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");

		onZChar = Physics.Raycast(RB.transform.position, new Vector3(0, 0, 1), out hit, moveZ) && hit.transform.tag == "player";
		onNegZChar = Physics.Raycast(RB.transform.position, new Vector3(0, 0, -1), out hit, moveZ)&& hit.transform.tag == "player";
		onXChar = Physics.Raycast(RB.transform.position, new Vector3(1, 0, 0), out hit, moveX)&& hit.transform.tag == "player";
		onNegXChar = Physics.Raycast(RB.transform.position, new Vector3(-1, 0, 0), out hit, moveX)&& hit.transform.tag == "player";

        Debug.DrawRay(RB.transform.position, new Vector3(0, 0, 1) * moveZ, Color.red);

        Debug.DrawRay(RB.transform.position, new Vector3(0, 0, -1) * moveZ, Color.red);

        Debug.DrawRay(RB.transform.position, new Vector3(1,0,0) * moveX, Color.red);

        Debug.DrawRay(RB.transform.position, new Vector3(-1, 0, 0) * moveX, Color.red);
    }



    protected void moveRight()
    {
        RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y, RB.transform.position.z + moveZ);
    }

    protected void moveLeft()
    {
        RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y, RB.transform.position.z - moveZ);
    }

    protected void moveUp()
    {
        RB.transform.position = new Vector3(RB.transform.position.x - moveX, RB.transform.position.y, RB.transform.position.z);
    }

    protected void moveDown()
    {
        RB.transform.position = new Vector3(RB.transform.position.x + moveX, RB.transform.position.y, RB.transform.position.z);
    }
}
