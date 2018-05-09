using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MenuController : MonoBehaviour {
	public GameObject Options;
	public GameObject Scoreboard;

	public GameObject Music;

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

		Score1.text = "Time Remaining: " + Mathf.Floor((Scores[0] / 60)).ToString("00") + ":" + (Scores[0] % 60).ToString("00");
		Score2.text = "Time Remaining: " + Mathf.Floor((Scores[1] / 60)).ToString("00") + ":" + (Scores[1] % 60).ToString("00");
		Score3.text = "Time Remaining: " + Mathf.Floor((Scores[2] / 60)).ToString("00") + ":" + (Scores[2] % 60).ToString("00");
		Score4.text = "Time Remaining: " + Mathf.Floor((Scores[3] / 60)).ToString("00") + ":" + (Scores[3] % 60).ToString("00");
		Score5.text = "Time Remaining: " + Mathf.Floor((Scores[4] / 60)).ToString("00") + ":" + (Scores[4] % 60).ToString("00");
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

	public void ChangeMusic() {
		if (PlayerPrefs.GetInt ("music", 0) == 1) {
			PlayerPrefs.SetInt ("music", 0);
			Music.SetActive(false);
		} 
		else {
			PlayerPrefs.SetInt ("music", 1);
			Music.SetActive(true);
		}
	}
}