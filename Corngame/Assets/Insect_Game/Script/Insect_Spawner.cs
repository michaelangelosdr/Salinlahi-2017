using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect_Spawner : MonoBehaviour {

	public float Timer_Cap;
	public float Timer_Count;
	public int bug_Count;

	public List<GameObject> Bug_Types;
	public List<GameObject> Bug_Spawn_points;
	public List<GameObject> Bugs;

	public bool spawningBugs;

	void Start () {
		bug_Count = 0;
		Timer_Count = Timer_Cap;
	}

	public void StartRound(int enemyCount) {

		StartCoroutine (StartSpawning (enemyCount));
	}

	public void Randomize_Spawn()
	{ 

		int G = Random.Range (0, Bug_Spawn_points.Count);
		int TypeIndex = Random.Range (0, Bug_Types.Count);


		GameObject Enemy1 = Instantiate (Bug_Types [TypeIndex], Bug_Spawn_points [G].transform.position, Quaternion.Euler(0,0,90)) as GameObject;

		switch(TypeIndex)
		{
		case 0:
			Enemy1.name = "Normal Bug";
			break;
		case 1:
			Enemy1.name = "Fast Bug";
			break;
		case 2:
			Enemy1.name = "Tank Bug";
			break;
		}

	/*	Bugs [bug_Count].SetActive (true);
	//	Bugs [bug_Count].GetComponent<Bug_Script> ().Randomize_Bug_Kind ();
	//	Bugs [bug_Count].GetComponent<Bug_Script> ().SummonBug (Bug_Spawn_points [G]);
		//Increases next pool Object
		if (bug_Count == Bugs.Count - 1) {
			bug_Count = 0;
		} else {
			bug_Count++;
		}*/
	}

	IEnumerator StartSpawning(int enemyCount) {

		yield return null;

		spawningBugs = true;

		int currentCount = 0;

		while(currentCount < enemyCount) {

			yield return new WaitForSeconds (1 + Random.value);

			Randomize_Spawn ();

			currentCount++;
		}

		spawningBugs = false;
	}
}
