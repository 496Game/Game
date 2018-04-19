﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public GameObject Options;
	public GameObject Scoreboard;

	public Text Score1;
	public Text Score2;
	public Text Score3;
	public Text Score4;
	public Text Score5;

	void Awake() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		Debug.Log(PlayerPrefs.GetString("scores"));
	}

	public void PlayGame() {
		SceneManager.LoadScene("Game");
	}

	public void OptionsClick() {
		Options.GetComponent<Animator>().SetTrigger("MenuIn");

		if (Scoreboard.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MenuIn")) {
			Scoreboard.GetComponent<Animator>().SetTrigger("MenuOut");
		}
	}

	public void ScoreboardClick() {
		Scoreboard.GetComponent<Animator>().SetTrigger("MenuIn");

		if (Options.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MenuIn	")) {
			Options.GetComponent<Animator>().SetTrigger("MenuOut");
		}
	}

	public void Quit() {
		Application.Quit();
	}
}