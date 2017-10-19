using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Attack_Box1 : MonoBehaviour {


	GameObject[] row2_towers;
	int Enemycounter;

	void FixedUpdate()
	{

		row2_towers = GameObject.FindGameObjectsWithTag ("row2");
		Debug.Log (Enemycounter);

	}

		void OnTriggerEnter2D(Collider2D c) {

			if (c.CompareTag ("Enemy"))
		{
			Enemycounter++;
			Debug.Log ("Row 2 has enemies");
			foreach (GameObject tower in row2_towers) {

					tower.gameObject.GetComponent<BugAway_Tower_Shooter> ().StartAttacking ();
				
			}

		}
			
		}

	void OnTriggerExit2D(Collider2D c)
	{
			if (c.CompareTag ("Enemy"))
			{
			Enemycounter--;
			Debug.Log ("No Enemies");

			}
		

	}



}
