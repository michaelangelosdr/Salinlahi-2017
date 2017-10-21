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
        if (this.towerName == "Punching Sack")
        {

        }
        else
        {
            Debug.Log("BASE: START ATTACKING");
            attacking = true;

            StartCoroutine(Attacking());
        }
    }

    public void StopAttacking() {

        Debug.Log("BASE: STOP ATTACKING");
        attacking = false;
    }

    public void Die()
    {
        Destroy(gameObject);
        //Insert Particles Here
    }

    public void Damage_This_Tower()
    {
        //fuck you tower take that
        if (health > 1)
            health -= 1;
        else
            Die();
    }

	public void Upgrade()
	{

	}

	IEnumerator Attacking() {

		while (attacking) {

			Instantiate (bullet, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);

			yield return new WaitForSeconds (attackSpeed);
		}
	}
}
