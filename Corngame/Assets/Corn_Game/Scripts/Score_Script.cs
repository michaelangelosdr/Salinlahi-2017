using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour {

	private int Main_Score;

	[SerializeField] GameObject Score_Text;
	[SerializeField] Corn_boi_AnimatorController Corn_boi;

	// Use this for initialization
	void Start () {
	Main_Score = 0;	
	}

	public void Main_Score_Add()
	{
	Main_Score++;
	Corn_boi.Play_Throw_Animation ();
	Score_Text.GetComponent<Text> ().text = Main_Score.ToString();
	}

	public int Get_Score()
	{
		return Main_Score;
	}

}
