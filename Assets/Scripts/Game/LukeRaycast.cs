using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukeRaycast : MonoBehaviour {

	GameObject paddle;

	Paddle ps;
	Ball bl;
	void Start(){
		bl = GameObject.FindGameObjectWithTag ("Ball").GetComponent<Ball> ();
		ps = GameObject.FindGameObjectWithTag ("Paddle").GetComponent<Paddle> ();
		paddle = GameObject.FindGameObjectWithTag ("Paddle");
	
	}
	void Update() {
		if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.rigidbody != null) {
					hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
					if(hit.transform.tag == "Paddle"){
						if(Input.GetKeyDown((KeyCode.Mouse1))){
							bl.ballMove ();
						}
					}
				}
			}
        }
	}
}