using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CameraController : MonoBehaviour {
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
 
	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -60F;
	public float maximumY = 60F;
 
	float rotationX = 0F;
	float rotationY = 0F;
 
	void Update () {
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;

		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);

		transform.localRotation = yQuaternion * xQuaternion;
	}
 
	void Start ()
	{		
		Rigidbody rb = GetComponent<Rigidbody>();	

		if (rb) {
			rb.freezeRotation = true;
		}
	}
}