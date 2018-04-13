using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    public GameObject GO1;
    public GameObject GO2;
    public GameObject GO3;

    protected EnemyMove enemy1;
    protected EnemyMove enemy2;
    protected EnemyMove enemy3;

    // Use this for initialization
    void Start () {
        enemy1 = GO1.GetComponent<EnemyMove>();
        enemy2 = GO2.GetComponent<EnemyMove>();
        enemy3 = GO3.GetComponent<EnemyMove>();

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine("MoveOrder");
            
        }

	}

    IEnumerator MoveOrder()
    {
        enemy1.structureMove();
        yield return new WaitForSeconds(1);
        enemy2.structureMove();
        yield return new WaitForSeconds(1);
        enemy3.structureMove();
    }
}
