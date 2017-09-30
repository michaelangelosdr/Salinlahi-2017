using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Script : MonoBehaviour {

	public int Max_Lives;
	int Player_Lives;


	// Use this for initialization
	void Start () {
		Player_Lives = Max_Lives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DecreaseLife()
	{
		if (Player_Lives != 0) {
			Player_Lives--;
			Debug.Log ("Minus 1");
		}
	}


	public int GetLives()
	{
		return Player_Lives;
	}
}
