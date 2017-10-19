using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_Shooter :BugAway_Tower_BASEclass {


	public BugAway_Tower_Shooter()
	{
		Health = 1;
		TowerName = "Wasp Shooter";
		AttackSpeed = 1;
		TowerCost = 10;
	}


	public new void Shoot()
	{
		Debug.Log (this.TowerName + "Shoots");
	}

	public new void Die()
	{

	}
		

	public new void Upgrade()
	{


	}


}
