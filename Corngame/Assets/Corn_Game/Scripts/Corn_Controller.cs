using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn_Controller : MonoBehaviour {

	public List<GameObject> Corn_objects;
	[SerializeField] List<Corn_Script> Corn_Scripts;
	[SerializeField] timer_script TIMER_SCRIPT;
	public int Max_Rotten_Corn;


	void Awake()
	{
		Max_Rotten_Corn = 3;
		Corns_Tappable (true);
		Spawn_Corn ();
		Randomize_Corn (Max_Rotten_Corn);
		TIMER_SCRIPT.Timer_Reset ();
	}


	public void Spawn_Corn()
	{
		foreach (GameObject corn in Corn_objects) {
			if (Max_Rotten_Corn <= 4) {
				corn.GetComponent<Corn_Script> ().Summon_Corn (0);
			} else if (Max_Rotten_Corn >= 5) {

				corn.GetComponent<Corn_Script>().Summon_Corn(Random.Range(0,3));
			}


		}
	}


	public void Randomize_Corn(int Max)
	{
		//
		//corn_objects = this.Corn_objects;

		for (int x = 0; x <= Max - 1; x++) {
			


			int Corn_num = Random.Range (0, 9);

		if (Corn_objects[Corn_num].GetComponent<Corn_Script> ().CheckCorn () == false) {
			Corn_objects[Corn_num].GetComponent<Corn_Script> ().ChangeCorn ();
			//return;
		} else {
				
			x--;
		}	
			
		}
		Debug.Log ("End");


	}

	public bool All_Corn_tapped()
	{

		for (int x = 0; x < Corn_objects.Count ; x++) {
			
			if (Corn_objects [x].GetComponent<Corn_Script> ().CheckCorn ()) {
				return !Corn_objects [x].GetComponent<Corn_Script> ().CheckCorn ();
			}
		}		

		return true;

	}

	public void Corns_Tappable(bool is_tappable)
	{
		foreach (GameObject corn in Corn_objects) {
			corn.GetComponent<Corn_Script> ().IS_Tappable = is_tappable;
		}


	}

	public void Increase_Max_Corn()
	{
		
		if (Max_Rotten_Corn >= 3 && Max_Rotten_Corn <= 8) {
			Max_Rotten_Corn++;
		}


	}

		
}
