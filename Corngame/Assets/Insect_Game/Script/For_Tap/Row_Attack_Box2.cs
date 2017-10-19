using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Attack_Box2 : MonoBehaviour {


	GameObject[] row3_towers;

	void FixedUpdate()
	{

		row3_towers = GameObject.FindGameObjectsWithTag ("row3");


	}

		void OnTriggerEnter2D(Collider2D c) {

			if (c.CompareTag ("Enemy"))
		{
			Debug.Log ("Row 3 has enemies");
			foreach (GameObject tower in row3_towers) {
				tower.gameObject.GetComponent<BugAway_Tower_Shooter> ().StartAttacking ();
			}

		}
			
		}



}
