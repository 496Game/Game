using System.Collections;
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
	public bool LukeGameComplete   = false;
	public bool NicoleGameComplete = false;

	public GameObject LukeManager;

	public Text MaxStatus;
	public Text EmilyStatus;
	public Text LukeStatus;
	public Text NicoleStatus;

	public GameObject MaxButton;
	public GameObject EmilyButton;
	public GameObject LukeButton;
	public GameObject NicoleButton;

	public GameObject MaxGlass;
	public GameObject EmilyGlass;
	public GameObject LukeGlass;
	public GameObject NicoleGlass;

	public GameObject Door;
	public AudioSource DoorMove;
	public AudioSource GameWin;

	public Text Timer;
	float TimeRemaining = 600f;
	float EndTime = 0;

	GameObject PreviousGame;

	void Start() {
		CurrentState = GameState.Start;
		StartCoroutine(GameTimer());
	}

	public void MaxGame() {
		CurrentState = GameState.Max;
		MaxButton.GetComponent<Animator>().SetTrigger("Switch");
	}

	public void EmilyGame() {
		CurrentState = GameState.Emily;
		EmilyButton.GetComponent<Animator>().SetTrigger("Switch");
	}

	public void LukeGame() {
		CurrentState = GameState.Luke;
		LukeButton.GetComponent<Animator>().SetTrigger("Switch");
	}

	public void NicoleGame() {
		CurrentState = GameState.Nicole;
		NicoleButton.GetComponent<Animator>().SetTrigger("Switch");
	}

	public void CheckStatus(Text state, bool complete) {
		if (complete) {
			state.text = "Game Complete!";
		} 
		else {
			state.text = "Needs to be done!";	
		}
	}

	public void CheckVictory() {
		if (MaxGameComplete) {
			MaxButton.transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.green;
			MaxButton.GetComponent<Collider> ().enabled = false;
			MaxStatus.text = "Game Completed!";
			MaxStatus.color = Color.green;
			GameWin.Play();
		} 
		else {
			MaxStatus.text = "Needs to be done!";
			MaxStatus.color = Color.red;
		}

		if (EmilyGameComplete) {
			EmilyButton.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
			EmilyButton.GetComponent<Collider> ().enabled = false;
			EmilyStatus.text = "Game Completed!";
			EmilyStatus.color = Color.green;
			GameWin.Play();
		} 
		else {
			EmilyStatus.text = "Needs to be done!";
			EmilyStatus.color = Color.red;
		}

		if (LukeGameComplete) {
			LukeButton.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
			LukeButton.GetComponent<Collider> ().enabled = false;
			LukeStatus.text = "Game Completed!";
			LukeStatus.color = Color.green;
			GameWin.Play();
		} 
		else {
			LukeStatus.text = "Needs to be done!";
			LukeStatus.color = Color.red;
		}

		if (NicoleGameComplete) {
			NicoleButton.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
			NicoleButton.GetComponent<Collider> ().enabled = false;
			NicoleStatus.text = "Game Completed!";
			NicoleStatus.color = Color.green;
			GameWin.Play();
		} 
		else {
			NicoleStatus.text = "Needs to be done!";
			NicoleStatus.color = Color.red;
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
				GetComponent<MaxRaycast> ().enabled = true;
				MaxGlass.GetComponent<Animator> ().SetTrigger ("GlassUp");
				PreviousGame = MaxGlass;
				DoorMove.Play();
				break;
			case GameState.Emily:
				GetComponent<EmilyRaycast>().enabled = true;
				EmilyGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = EmilyGlass;
				DoorMove.Play();
				break;
		case GameState.Luke:
				LukeManager.SetActive (true);
				LukeGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = LukeGlass;
				DoorMove.Play();
				break;
			case GameState.Nicole:
				GetComponent<NicoleRaycast>().enabled = true;
				NicoleGlass.GetComponent<Animator>().SetTrigger("GlassUp");
				PreviousGame = NicoleGlass;
				DoorMove.Play();
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

		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void DisableScripts() {
		LukeManager.SetActive (false);
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
