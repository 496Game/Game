using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject Options;
	public GameObject Scoreboard;

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