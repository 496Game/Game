﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public enum GameState {Start, Max, Emily, Luke, Nicole, Win, Lose};
	public GameState CurrentState;

	public bool MaxGameComplete    = false;
	public bool EmilyGameComplete  = false;
	public bool LukeGameComplete   = false;
	public bool NicoleGameComplete = false;

	public GameObject MaxGlass;
	public GameObject EmilyGlass;
	public GameObject LukeGlass;
	public GameObject NicoleGlass;

	public GameObject Door;

	public Text Timer;
	float TimeRemaining = 600f;

	GameObject PreviousGame;

	void Start() {
		CurrentState = GameState.Start;
		StartCoroutine(GameTimer());
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
				Door.GetComponent<Animator>().SetTrigger("DoorOpen");
				Door.GetComponent<Collider>().enabled = true;
				StopCoroutine("GameTimer");
				break;
			case GameState.Lose:
				SceneManager.LoadScene("Loss");
				break;
			default:
				GetComponent<MaxRaycast>().enabled = true;
				break;
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

			if (i <= 0) {
				CurrentState = GameState.Lose;
				SwitchGames();
			}
		}
	}
}