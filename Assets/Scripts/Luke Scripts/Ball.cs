using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;


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

//	void OnCollisionEnter(Collider coll){
//		if(coll.gameObject.tag == "Paddle"){
//			rb.velocity = Quaternion.AngleAxis (-15, Vector3.up) * -rb.velocity;
//		}
//	}
}
