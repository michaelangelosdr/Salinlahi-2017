using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_GameController : MonoBehaviour {


	[SerializeField] Corn_Controller corn_Controller;
	[SerializeField] GameObject CornField;
	[SerializeField] Score_Script score_scipt;
	[SerializeField] timer_script TIMER_SCRIPT;
	[SerializeField] Health_script HEALTH_SCRIPT;
	[SerializeField] GameObject Main_Canvass;
	[SerializeField] GameObject GameOver_Canvas;
	[SerializeField] GameObject Score_text;
	[SerializeField] GameObject Trivia_Canvas;
	[SerializeField] GameObject Tutorial_Canvass;
	[SerializeField] GameObject T_Text_1;
	[SerializeField] GameObject T_Text_2;
	[SerializeField] GameObject Corn_Boy;


	int Tutorial_inc;

	void Start()
	{
		Reset_To_Tutorial ();
		corn_Controller.Corns_Tappable (false);
		TIMER_SCRIPT.Timer_Stop ();
	}

	
	// Update is called once per frame
	void Update () {
	


		if (Input.GetKeyDown (KeyCode.R)) {
			
			re_randomize ();
		}

		if (corn_Controller.All_Corn_tapped () == true) {
			//Insert Animation Script here 


			if (score_scipt.Get_Score () % 10 == 0) {
				corn_Controller.Increase_Max_Corn ();
				TIMER_SCRIPT.DecreaseTime ();
			}
			Debug.Log ("Check This");
			//TIMER_SCRIPT.Timer_Reset ();
			re_randomize ();
		}



	}

	private void re_randomize()
	{
		corn_Controller.Spawn_Corn ();
		corn_Controller.Randomize_Corn (corn_Controller.Max_Rotten_Corn);
	}


	public void Add_Score()
	{
		score_scipt.Main_Score_Add ();

	}
	public void Life_Decreased()
	{
		HEALTH_SCRIPT.Decrease_Life ();
	}


	public void RestartGame()
	{
		GameObject.Find("Unity_SceneManager").GetComponent<Scene_Manager_Script>().Call_Scene(1);
	}

	public void Open_Trivia()
	{
		GameOver_Canvas.SetActive (false);
		Trivia_Canvas.SetActive (true);
	}
	public void Close_Trivia()
	{
		Trivia_Canvas.SetActive (false);
		Show_Gameoverscreen ();
	}

	public void Return_To_Menu()
	{
		//Load Menu
		GameObject.Find("Unity_SceneManager").GetComponent<Scene_Manager_Script>().Call_Scene(0);
	}

	public void Is_GameOver()
	{
		Show_Gameoverscreen ();
		CornField.SetActive (false);
	}


	public void Reset_To_Tutorial()
	{
		Tutorial_inc = 0;
		Tutorial_Canvass.SetActive (true);
		T_Text_1.SetActive (true);
		T_Text_2.SetActive (false);
	}

	public void Tap_Tutorial()
	{
		if (Tutorial_inc == 0) {
			T_Text_1.SetActive (false);
			T_Text_2.SetActive (true);
			Tutorial_inc++;
		} else {
			Tutorial_Canvass.SetActive (false);
			Main_Canvass.SetActive (true);
			corn_Controller.Corns_Tappable (true);
			TIMER_SCRIPT.Timer_Resume ();
			Tutorial_inc = 0;
		}


	}


	private void Show_Gameoverscreen()
	{
		
		Main_Canvass.SetActive (false);
		GameOver_Canvas.SetActive (true);
		Score_text.GetComponent<Text> ().text = score_scipt.Get_Score ().ToString();
	}

}
