using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter (Collider col)
	{
		GM.instance.LoseLife();
		Destroy (GameObject.FindGameObjectWithTag ("Ball"));
		print("Ball hit");
	}
}
