using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	public enum GameState {Start, Max, Emily, Luke, Nicole, End};
	public GameState CurrentState;

	void Start() {
		CurrentState = GameState.Start;
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

	public void SwitchGames() {
		DisableScripts();

		//@todo: Move glass planes/open final door when complete
		switch (CurrentState) {
			case GameState.Max:
				GetComponent<MaxRaycast>().enabled = true;
				break;
			case GameState.Emily:
				GetComponent<EmilyRaycast>().enabled = true;
				break;
			case GameState.Luke:
				GetComponent<LukeRaycast>().enabled = true;
				break;
			case GameState.Nicole:
				GetComponent<NicoleRaycast>().enabled = true;
				break;
			case GameState.End:
				break;
			default:
				GetComponent<MaxRaycast>().enabled = true;
				break;
		}
	}

	public void DisableScripts() {
		GetComponent<EmilyRaycast>().enabled = false;
		GetComponent<LukeRaycast>().enabled = false;
		GetComponent<MaxRaycast>().enabled = false;
		GetComponent<NicoleRaycast>().enabled = false;
	}
}
