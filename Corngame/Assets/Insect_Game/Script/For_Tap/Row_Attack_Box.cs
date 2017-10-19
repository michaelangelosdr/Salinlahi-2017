using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Attack_Box : MonoBehaviour {


	GameObject[] row1_towers;
	int EnemyCounter;

	void FixedUpdate()
	{
		row1_towers = GameObject.FindGameObjectsWithTag ("row1_tower");
		if (EnemyCounter > 0) {
			foreach (GameObject tower in row1_towers) {	
				tower.gameObject.GetComponent<BugAway_Tower_Shooter> ().StartAttacking ();
			}	
		} else {
			foreach (GameObject tower in row1_towers) {
				tower.gameObject.GetComponent<BugAway_Tower_Shooter> ().StopAttacking ();
			}	
		}


	}

		void OnTriggerEnter2D(Collider2D c) {
			if (c.CompareTag ("Enemy"))
		{
			EnemyCounter++;
		}
			
		}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.CompareTag ("Enemy")) {
			EnemyCounter--;
		}
	}



}
