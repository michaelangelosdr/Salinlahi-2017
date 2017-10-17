using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_BASEclass : MonoBehaviour {

	public int health;
	public int towerCost;
	public string towerName;
	public float attackSpeed;
	public bool attacking;

	public GameObject bullet;

	public int Health
	{
		get { return Health; }
		set { Health = value; }
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
		health = 1;
		towerName = "Basic Tower";
		attackSpeed = 1;
		towerCost = 10;
	}

	public BugAway_Tower_BASEclass(int newHealth, string newTowerName, float newAttackSpeed, int newTowerCost)
	{
		health = newHealth;
		towerName = newTowerName;
		attackSpeed = newAttackSpeed;
		towerCost = newTowerCost;
	}

	public void StartAttacking() {

		Debug.Log ("BASE: START ATTACKING");
		attacking = true;

		StartCoroutine (Attacking ());
	}

	public void StopAttacking() {

		Debug.Log ("BASE: STOP ATTACKING");
		attacking = false;
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

	IEnumerator Attacking() {

		while (attacking) {

			Instantiate (bullet, transform.position, Quaternion.identity);

			yield return new WaitForSeconds (attackSpeed);
		}
	}
}
