using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;

	public Vector3 playerPos = new Vector3(-46.86f, 3.0f, .61f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float zPos = transform.position.z + (Input.GetAxis ("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (-46.86f, 3.02f, Mathf.Clamp (-4.33f, 5.33f, zPos));
		transform.position = playerPos;
	}
}
