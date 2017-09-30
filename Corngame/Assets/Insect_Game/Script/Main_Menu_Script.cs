using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Script : MonoBehaviour {


	public List<GameObject> GameTitle_Canvass;

	[SerializeField] GameObject GameValues;
	[SerializeField] Scene_Manager_Script Scene_Manager;
	int Default_Val;


	// Use this for initialization
	void Start () {
		Default_Val = GameValues.GetComponent<Game_Values>().Default_Menu_Value;
		foreach (GameObject C in GameTitle_Canvass) {
			C.SetActive (false);
		}

		GameTitle_Canvass [Default_Val].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GoRight()
	{

		if (Default_Val >= GameTitle_Canvass.Count - 1) {
			Default_Val = 0;
		}
		else
		Default_Val++;



		Change_Screen ();
	}
	public void GoLeft()
	{if (Default_Val <= 0) {
			Default_Val = 3;
		}
		Default_Val--;

		Change_Screen ();
	}


	public void Change_Screen()
	{
		foreach (GameObject g in GameTitle_Canvass) {
			g.SetActive (false);
		}
		GameTitle_Canvass [Default_Val].SetActive (true);
	}

	public void Start_Button_Functionality()
	{
		Debug.Log (Default_Val);
		Scene_Manager.Call_Scene (Default_Val + 1);
	}

}
