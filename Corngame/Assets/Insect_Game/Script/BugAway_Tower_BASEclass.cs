using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_BASEclass : MonoBehaviour {

    public int health;
    public int towerCost;
    public string towerName;
    public float attackSpeed;
    public bool attacking;

	PoolScript bulletPool;

    public GameObject bullet;
	private GridScriptTAP Grid;

	public Animator ac;

	void Start() {
	
		bulletPool = GameObject.FindGameObjectWithTag ("Bullet Pool").GetComponent<PoolScript> ();
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

	void Update() {
	
		ac.SetBool ("attacking", attacking);
	}

    public virtual void StartAttacking() {
        if (this.towerName == "Punching Sack")
        {

        }
        else
        {
//            Debug.Log("BASE: START ATTACKING");
            attacking = true;
        }
    }

    public virtual void StopAttacking() {
//        Debug.Log("BASE: STOP ATTACKING");
        attacking = false;
    }

	public void Shoot() {

		SFXScript.Instance.BugAwayPlaySFX ("tower1_shoot");
		GameObject newBullet = bulletPool.GetNext ();

		if (newBullet) {

			newBullet.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			newBullet.transform.rotation = Quaternion.identity;
			newBullet.SetActive (true);
		} else {

			Debug.Log ("no bullet");
		}
	}

    public void Die()
    {

        Grid.GetComponent<GridScriptTAP>().Restore_Grid();
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

	public void SetGrid(GridScriptTAP grid)
    {
        Grid = grid;

    }
}
