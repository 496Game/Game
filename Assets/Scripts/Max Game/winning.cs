using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour {


	manager man;
	// Use this for initialization
	void Start () {
		man = GameObject.FindGameObjectWithTag ("manager").GetComponent<manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.CompareTag("player"))
		{
			
		}
	}
}
