using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MenuController : MonoBehaviour {
	public GameObject Options;
	public GameObject Scoreboard;

	public AudioSource ButtonClick;

	public Text Score1;
	public Text Score2;
	public Text Score3;
	public Text Score4;
	public Text Score5;

	void Awake() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		var Scores = PlayerPrefs.GetString("scores", "0;0;0;0;0").Split(';').Select(s => float.Parse(s)).ToArray();

		Score1.text = "Time Remaining: " + Scores[0].ToString();
		Score2.text = "Time Remaining: " + Scores[1].ToString();
		Score3.text = "Time Remaining: " + Scores[2].ToString();
		Score4.text = "Time Remaining: " + Scores[3].ToString();
		Score5.text = "Time Remaining: " + Scores[4].ToString();
	}

	public void PlayGame() {
		SceneManager.LoadScene("Game");
		ButtonClick.Play ();
	}

	public void OptionsClick() {
		Options.GetComponent<Animator>().SetTrigger("MenuIn");
		ButtonClick.Play ();

		if (Scoreboard.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MenuIn")) {
			Scoreboard.GetComponent<Animator>().SetTrigger("MenuOut");
		}
	}

	public void ScoreboardClick() {
		Scoreboard.GetComponent<Animator>().SetTrigger("MenuIn");
		ButtonClick.Play ();

		if (Options.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MenuIn")) {
			Options.GetComponent<Animator>().SetTrigger("MenuOut");
		}
	}

	public void Quit() {
		ButtonClick.Play ();
		Application.Quit();
	}
}