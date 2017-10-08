using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script_Insectgame : MonoBehaviour {

	public List<GameObject> Vector_Points;

	private int playerPosInt;

	private float PlayerX;
	private float PlayerY;


	// Use this for initialization
	void Start () {
		
		PlayerX = transform.position.x;
		PlayerY = transform.position.y;
		playerPosInt = 4;
		UpdatePos ();
	}

	public void UpdatePos()
	{
		transform.position = Vector_Points [playerPosInt].transform.position;
	}
		
	void Update () {

		#if UNITY_EDITOR
		if (Input.anyKeyDown) {
		
			if (Input.GetAxisRaw ("Horizontal") != 0)
				Move_Char ((int)Input.GetAxisRaw ("Horizontal"));
			else if(Input.GetAxisRaw ("Vertical") != 0)
				Move_Char ((int)Input.GetAxisRaw ("Vertical") * -3);
		}
		#endif
	}

	public void Move_Char(int dir)
	{
		int previousPlayerInt = playerPosInt;

		playerPosInt += dir;

		if (playerPosInt < 0 || playerPosInt >= Vector_Points.Count)
			playerPosInt = previousPlayerInt;

		UpdatePos ();
	}
}
