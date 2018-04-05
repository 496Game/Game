using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {
	void Update() {
		if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) {
					hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
				}
			}
        }
	}
}