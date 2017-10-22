using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugaway_Enemies_FastBug : Bugaway_Enemies_BaseClass {

	void OnEnable()
	{
		Health = 3;
		speed = 2;
		Damage = 1;
	}

	void FixedUpdate()
	{
		Move (new Vector2(transform.position.x,transform.position.y));

	}

	public override void Move(Vector2 Position)
	{
		float yMovement = Position.y;
		yMovement += speed/50;
		transform.position = new Vector2 (Position.x, yMovement);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Endpoint") {
			KillBug (this.gameObject);
		}        
        if (col.CompareTag ("Bullet")) {
			Getdamaged ();
		}
        if (col.CompareTag("row1_tower") || col.CompareTag("row2_tower") || col.CompareTag("row3_tower") )
        {

			if (!col.GetComponent<BugAway_Tower_Bomb> ()) {

				col.GetComponent<BugAway_Tower_BASEclass>().Damage_This_Tower();
				KillBug(this.gameObject);
			}
        }

	}
}
