using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect_Score_Script : MonoBehaviour {


	int Score;
	int Final_Score;



	public void AddScore()
	{
		Score++;
		Debug.Log ("Added one");
	}
	public int GetScore()
	{
		return Score;
	}


}
