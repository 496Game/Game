﻿using System.Collections;
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
					if (hit.transform.tag == "left") 
					{
						hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
						move.left = true;
					}

					if (hit.transform.tag == "right") 
					{
						hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
						move.right = true;
					}

					if (hit.transform.tag == "up") 
					{
						hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
						move.up = true;
					}

					if (hit.transform.tag == "down") 
					{
						hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
						move.down = true;
					}
				}
			}
        }
	}
}