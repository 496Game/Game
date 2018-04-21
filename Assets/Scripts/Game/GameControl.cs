﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Playables;

public class GameControl : MonoBehaviour {
	public enum GameState {Start, Max, Emily, Luke, Nicole, Win, Lose};
	public GameState CurrentState;

	public GameObject Timeline;
	public GameObject TimelineCamera;

	public bool MaxGameComplete    = false;
	public bool EmilyGameComplete  = false;
	public bool LukeGameComplete   = true;
	public bool NicoleGameComplete = false;

	public GameObject MaxButton;
	public GameObject EmilyButton;
	public GameObject LukeButton;
	public GameObject NicoleButton;

	public GameObject MaxGlass;
	public GameObject EmilyGlass;
	public GameObject LukeGlass;
	public GameObject NicoleGlass;

	public GameObject Door;

	public Text Timer;
	float TimeRemaining = 600f;
	float EndTime = 0;

	GameObject PreviousGame;

	void Start() {
		CurrentState = GameState.Start;
		StartCoroutine(GameTimer());
		//CurrentState = GameState.Win;
		//SwitchGames();
	}

	public void MaxGame() {
		CurrentState = GameState.Max;
	}

	public void EmilyGame() {
		CurrentState = GameState.Emily;
	}

	public void LukeGame() {
		CurrentState = GameState.Luke;
	}

	public void NicoleGame() {
		CurrentState = GameState.Nicole;
	}

	public void CheckVictory() {
		if (MaxGameComplete) {
			MaxButton.GetComponent<Renderer>().material.color = Color.green;
		}

		if (EmilyGameComplete) {
			EmilyButton.GetComponent<Renderer>().material.color = Color.green;
		}

		if (LukeGameComplete) {
			LukeButton.GetComponent<Renderer>().material.color = Color.green;
		}

		if (NicoleGameComplete) {
			NicoleButton.GetComponent<Renderer>().material.color = Color.green;
		}

		if (MaxGameComplete && EmilyGameComplete && LukeGameComplete && NicoleGameComplete) {
			CurrentState = GameState.Win;
			SwitchGames();
		}
	}

	public void SwitchGames() {
		DisableScripts();

		if (PreviousGame) {
			PreviousGame.GetComponent<Animator>().SetTrigger("GlassDown");
		}

		switch (CurrentState) {
			case GameState.Max:
				GetComponent<MaxRaycast>().enabled = true;
				MaxGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = MaxGlass;
				break;
			case GameState.Emily:
				GetComponent<EmilyRaycast>().enabled = true;
				EmilyGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = EmilyGlass;
				break;
			case GameState.Luke:
				GetComponent<LukeRaycast>().enabled = true;
				LukeGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = LukeGlass;
				break;
			case GameState.Nicole:
				GetComponent<NicoleRaycast>().enabled = true;
				NicoleGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = NicoleGlass;
				break;
		case GameState.Win:
			TimelineCamera.SetActive(true);
			Timeline.GetComponent<PlayableDirector>().Play();
			Door.GetComponent<Animator>().SetTrigger("DoorOpen");
			Door.GetComponent<Collider>().enabled = true;
			StopCoroutine("GameTimer");
			PlayerPrefs.SetFloat("LastWin", EndTime);

			var Scores = PlayerPrefs.GetString("scores", "0;0;0;0;0").Split(';').Select(s => float.Parse(s)).ToArray();
			for (var ScoresIndex = 0; ScoresIndex < Scores.Length; ScoresIndex++) {
				if (EndTime > Scores[ScoresIndex]) {
					for (var ScoresShiftIndex = Scores.Length - 1; ScoresShiftIndex > ScoresIndex; ScoresShiftIndex--) {
						Scores[ScoresShiftIndex] = Scores[ScoresShiftIndex - 1];
					}

					Scores[ScoresIndex] = EndTime;

					break;
				}
			}

			PlayerPrefs.SetString("scores", string.Join(";", Scores.Select(i => i.ToString()).ToArray()));

			break;
			case GameState.Lose:
				SceneManager.LoadScene("Loss");
				break;
			default:
				GetComponent<MaxRaycast>().enabled = true;
				break;
		}
	}

	void Update() {
		if (CurrentState == GameState.Win) {
			if (Timeline.GetComponent<PlayableDirector>().state != PlayState.Playing) {
				TimelineCamera.SetActive(false);				
			}
		}
	}

	public void DisableScripts() {
		GetComponent<EmilyRaycast>().enabled  = false;
		GetComponent<LukeRaycast>().enabled   = false;
		GetComponent<MaxRaycast>().enabled    = false;
		GetComponent<NicoleRaycast>().enabled = false;
	}

	private IEnumerator GameTimer() {
		for (float i = TimeRemaining; i >= 0; i--) {
			yield return new WaitForSeconds(1);
			Timer.text = "Time Remaining: " + Mathf.Floor((i / 60)).ToString("00") + ":" + (i % 60).ToString("00");
			EndTime = i;
			PlayerPrefs.SetFloat("LastWin", i);

			if (i <= 0) {
				CurrentState = GameState.Lose;
				SwitchGames();
			}
		}
	}
}
