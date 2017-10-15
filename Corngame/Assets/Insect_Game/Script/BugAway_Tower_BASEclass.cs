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


	public BugAway_Tower_BASEclass()
	{
		Health = 1;
		TowerName = "Basic Tower";
		AttackSpeed = 1;
		TowerCost = 10;

	}

	public BugAway_Tower_BASEclass(int newHealth, string newTowerName, float newAttackSpeed, int newTowerCost)
	{
		Health = newHealth;
		TowerName = newTowerName;
		AttackSpeed = newAttackSpeed;
		TowerCost = newTowerCost;
	}


	public void Shoot()
	{

	}

	public void Die()
	{

	}

	public void Spawn()
	{

	}


	public void Upgrade()
	{

	}
		

}
