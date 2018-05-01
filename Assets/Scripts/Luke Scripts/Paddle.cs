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
		float zPos = transform.position.z;
		if(Input.GetKey(KeyCode.L)){
			zPos += paddleSpeed;
		}
		if(Input.GetKey(KeyCode.K)){
			zPos -= paddleSpeed;
		}
		playerPos = new Vector3 (-46.86f, 3.02f, zPos);
		transform.position = playerPos;
	}
}
