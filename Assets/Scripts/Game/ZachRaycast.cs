using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZachRaycast : MonoBehaviour {
	void Update() {
		if (Input.GetMouseButtonUp(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100)) {
                if (hit.rigidbody != null) {
					if (hit.transform.gameObject.layer == 8) {
						var tag = hit.transform.gameObject.tag;

						if (tag == "MaxGame") {
							GetComponent<GameControl>().MaxGame();
						}
						else if (tag == "EmilyGame") {
							GetComponent<GameControl>().EmilyGame();
						}
						else if (tag == "LukeGame") {
							GetComponent<GameControl>().LukeGame();
						}
						else if (tag == "NicoleGame") {
							GetComponent<GameControl>().NicoleGame();
						}

						GetComponent<GameControl>().SwitchGames();
					}
				}
			}
        }
	}
}