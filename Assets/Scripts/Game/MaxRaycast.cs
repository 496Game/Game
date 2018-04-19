using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxRaycast : MonoBehaviour {
	charMove move;

	void Start()
	{
		move = GameObject.FindGameObjectWithTag ("player").GetComponent<charMove>();
	}
	void Update() {
		if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) {
					if (hit.transform.tag == "left" && move.onNegZ== false) {
						hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
						move.moveUp ();
					}

				}
			}
        }
	}
}

					//	onZ = Physics.Raycast(RB.transform.position, RB.transform.right,  out hit, moveZ)&& (hit.transform.tag == "wall" || hit.transform.tag == "Enemy");