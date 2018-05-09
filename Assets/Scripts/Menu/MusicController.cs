using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	void Awake () {
		if (PlayerPrefs.GetInt ("music", 0) == 1) {
			this.gameObject.SetActive (false);
		} 
		else {
			this.gameObject.SetActive (true);
		}

		DontDestroyOnLoad(this.gameObject);

		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}
	}
}