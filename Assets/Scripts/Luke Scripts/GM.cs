using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public bool GAMEOVER = false;
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	//public GameObject deathParticles;
	public static GM instance = null;
	public GameObject Player;

	private GameObject clonePaddle;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Setup();

	}

	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		//Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			//Time.timeScale = .25f;
			//Invoke ("Reset", resetDelay);
			GAMEOVER = true;
			Player.GetComponent<GameControl> ().LukeGameComplete = true;
			Player.GetComponent<GameControl>().CheckVictory();
		}

		if (lives < 1)
		{
			gameOver.SetActive(true);
			//Time.timeScale = .25f;
			Reset ();
			//Invoke ("Reset", resetDelay);
		}

	}

	void Reset()
	{
		Destroy(GameObject.FindGameObjectWithTag("brick"));
		Time.timeScale = 1f;
		Instantiate(bricksPrefab, new Vector3(-40.63718f, 5.977097f, -.871537f), Quaternion.identity);
		lives = 3;
		bricks = 20;
		livesText.text = "Lives: " + lives;
		gameOver.SetActive (false);
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		//Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}