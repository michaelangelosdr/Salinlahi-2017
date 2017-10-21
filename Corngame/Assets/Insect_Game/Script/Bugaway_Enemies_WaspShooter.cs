using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugaway_Enemies_WaspShooter : Bugaway_Enemies_BaseClass {



	void Awake()
    { 
		Health = 4;
		speed = 1;
		Damage = 1;
	}


	void FixedUpdate()
	{
		
		Move (new Vector2(transform.position.x,transform.position.y));

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
