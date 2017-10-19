using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Values : MonoBehaviour {

	public int Default_Menu_Value;
	public bool From_Menu;


	public Game_Values()
	{
		Default_Menu_Value = 0;
		From_Menu = true;
	}



	public int GetDefault_Menu_Value()
	{
		return Default_Menu_Value;
	}

	
}
