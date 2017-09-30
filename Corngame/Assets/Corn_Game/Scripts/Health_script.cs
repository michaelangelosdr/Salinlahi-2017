using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_script : MonoBehaviour {

	public List<GameObject> corn_health;
	public int Life_Val;
	public bool Invincible;

	[SerializeField] Main_GameController M_Gamecontroller;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {





	}



	public void Increase_Life()
	{
		Life_Val++;
	}
	public void Decrease_Life ()
	{
		//Run Animation Script
		if (Life_Val > 1) {
			corn_health [Life_Val - 1].SetActive (false);
			Life_Val--;
		} else {

			M_Gamecontroller.Is_GameOver ();

		}
	}

	public int getLife_Val()
	{
		return Life_Val;
	}

}
