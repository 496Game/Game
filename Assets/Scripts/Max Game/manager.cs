using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	public GameObject GO1;
	public GameObject GO2;
	public GameObject GO3;
	public GameObject player;

	protected EnemyMove enemy1;
	protected EnemyMove enemy2;
	protected EnemyMove enemy3;

	protected Vector3 enemyStart1;
	protected Vector3 enemyStart2;
	protected Vector3 enemyStart3;
	protected Vector3 playerStart;

	charMove character;

	public bool reset = false;

	public bool win = false;
	// Use this for initialization
	void Start () {
		enemy1 = GO1.GetComponent<EnemyMove>();
		enemy2 = GO2.GetComponent<EnemyMove>();
		enemy3 = GO3.GetComponent<EnemyMove>();

		enemyStart1 = GO1.transform.position;
		enemyStart2 = GO2.transform.position;
		enemyStart3 = GO3.transform.position;
		playerStart = player.transform.position;

		character = GameObject.FindGameObjectWithTag ("player").GetComponent<charMove>();


	}

	// Update is called once per frame
	void Update () {

		StartCoroutine ("Reset");

	}

	IEnumerator MoveOrder()
	{
		yield return new WaitForSeconds(1);
		enemy1.structureMove();
		if (reset)
			yield break;
		yield return new WaitForSeconds(1);
		enemy2.structureMove();
		if (reset)
			yield break;
		yield return new WaitForSeconds(1);
		enemy3.structureMove();
		//character.StopCoroutine ("PlayerMove");

	}

	IEnumerator Reset()
	{
		if(reset)
		{
			reset = false;
			GO1.transform.position = enemyStart1;
			GO2.transform.position = enemyStart2;
			GO3.transform.position = enemyStart3;
			player.transform.position = playerStart;

		}

		return null;
	}
}
