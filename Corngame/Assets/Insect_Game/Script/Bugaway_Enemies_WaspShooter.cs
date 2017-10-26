using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugaway_Enemies_WaspShooter : Bugaway_Enemies_BaseClass {

	public InsectGameControllerTAP GMSCRIPT;

	void OnEnable()
    { 
		Health = 2 + GMSCRIPT.HealthIncrement;
		speed = 1 + GMSCRIPT.SpeedIncrement;
		Damage = 1;
	}
	void FixedUpdate()
	{		
		Move (new Vector2(transform.position.x,transform.position.y));
	}



	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Endpoint") {
			KillBug (this.gameObject);
		}

        if (col.CompareTag("row1_tower") || col.CompareTag("row2_tower") || col.CompareTag("row3_tower"))
        {

			if (!col.GetComponent<BugAway_Tower_Bomb> ()) {

				col.GetComponent<BugAway_Tower_BASEclass>().Damage_This_Tower();
				KillBug(this.gameObject);
			}
        }

		if (col.CompareTag ("Bullet")) {
			Getdamaged ();
		}

	}
}
