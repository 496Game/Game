using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// character move skeleton
// "more machine now than man, twisted and evil..."

public class charMove_skeleton : MonoBehaviour
{
	[SerializeField] private float forSpeed = 12f;
	[SerializeField] private float rotSpeed = 500f;

	Rigidbody rb;

	public bool grounded = true;

	float inputMoveVal = 0;
	float inputRotVal = 0;
	float yawRotation = 0;
	float pitchRotation = 0;
	float flight = 200;
	float yaw = 0;
	float pitch = 0;

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		}
	}

	void OnCOllisionExit(Collision other) {
		if (other.gameObject.tag == "Ground") {
			grounded = false;
		}
	}

	private void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}


	void Update () {
		inputMoveVal = Input.GetAxis("Vertical");
		inputRotVal = Input.GetAxis("Horizontal");
		yawRotation = Input.GetAxis("Mouse X");
		pitchRotation = Input.GetAxis("Mouse Y");

		pitch += pitchRotation * Time.deltaTime * 100f;
		yaw   += yawRotation   * Time.deltaTime * 100f;

		pitch = Mathf.Clamp(pitch, -45, 45);

		transform.rotation = Quaternion.Euler(0, yaw, 0);

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (grounded) {
				Jump();
			}
		}
	}

	void FixedUpdate () {
		Move();

		rb.velocity += new Vector3(0, -1, 0);
	}

	void Move () {
		Vector3 movement = new Vector3(inputRotVal, 0, inputMoveVal);
		movement.Normalize();

		Vector3 forwardAccel = transform.forward * movement.z;
		Vector3 sideAccel = -Vector3.Cross(transform.forward, Vector3.up) * movement.x;

		rb.AddForce(forwardAccel * forSpeed);
		rb.AddForce(sideAccel * forSpeed);
	}

	void Jump() {
		grounded = false;
		rb.velocity = new Vector3(0, 30, 0);
	}
}