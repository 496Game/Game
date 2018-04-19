using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour {
	public GameObject Player;

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
			//THIS IS THE WIN CONDITION!!!
			print ("fsdfsdfsd");
			man.win = true;
			Player.GetComponent<GameControl>().MaxGameComplete = true;
		}
	}
}
