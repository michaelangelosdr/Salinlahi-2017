using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_BASEclass {


	public int Health
	{
		get { return Health; }
		private set { Health = value; }
	}

	public string TowerName
	{
		get { return TowerName; }
		set { TowerName = value; }
	}

	public float AttackSpeed
	{
		get { return AttackSpeed;}
		set { AttackSpeed = value;}
	}

	public int TowerCost
	{
		get { return TowerCost; }
		set { TowerCost = value; }
	}

}
