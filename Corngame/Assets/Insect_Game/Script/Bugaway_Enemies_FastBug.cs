using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugaway_Enemies_FastBug : Bugaway_Enemies_BaseClass {

	void Awake()
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

			Debug.Log ("BUG IS OUT");
			KillBug (this.gameObject);
		}

		if (col.CompareTag ("Bullet")) {

			Debug.Log ("Aray");
			Getdamaged ();
		}

	}
}
