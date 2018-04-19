using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour {
	public Text TimeLeftText;

	void Awake() {
		float TimeLeft = PlayerPrefs.GetFloat("LastWin");
		TimeLeftText.text = "You won with " + Mathf.Floor((TimeLeft / 60)).ToString("00") + ":" + (TimeLeft % 60).ToString("00") + " minutes left!";
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}