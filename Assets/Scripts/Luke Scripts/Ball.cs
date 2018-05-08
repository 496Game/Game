using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 400f;


	private Rigidbody rb;
	private bool ballInPlay;

	void Awake () {

		rb = GetComponent<Rigidbody>();

	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.K) && ballInPlay == false)
		{
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
	}

	public void ballMove(){
		transform.parent = null;
		ballInPlay = true;
		rb.isKinematic = false;
		rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
	
	}
}
