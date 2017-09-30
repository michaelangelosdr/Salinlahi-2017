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
		playerPosInt = 0;
		ChangePos (playerPosInt);
	}
	
	// Update is called once per frame
	void Update () {



	}


	public void ChangePos(int Index)
	{
		transform.position = Vector_Points [Index+1].transform.position;
	}
		
	public void Move_Char(GameObject dir)
	{
		if (dir.gameObject.name == "Left_Button") {
			playerPosInt -= 1;
		}

		else if (dir.gameObject.name == "Right_Button") {
			playerPosInt += 1;
		}
		else if (dir.gameObject.name == "Down_Button") {
			playerPosInt += 3;
		}
		else if (dir.gameObject.name == "Up_Button") {
			playerPosInt -= 3;
		}

		ChangePos (playerPosInt);

	}




}
