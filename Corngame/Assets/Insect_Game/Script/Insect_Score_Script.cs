using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insect_Score_Script : MonoBehaviour {

	int Score;
	int Final_Score;

	public Text ui;


	void Start() {

		Score = 0;

		UpdateScoreUI ();
	}

	public void AddScore()
	{
		Debug.Log ("Score: " + Score);
		Score++;

		UpdateScoreUI ();
	}

	public int GetScore()
	{
		return Score;
	}

	void UpdateScoreUI() {
	
		ui.text = Score.ToString ();
	}

}
