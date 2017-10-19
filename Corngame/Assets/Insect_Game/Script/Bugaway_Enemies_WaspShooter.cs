using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugaway_Enemies_WaspShooter : Bugaway_Enemies_BaseClass {



	void Awake()
	{
		Debug.Log ("Summoned");
		Health = 5;
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
			gameObject.SetActive (false);
		}

		if (col.CompareTag ("Bullet")) {

			col.gameObject.SetActive (false);
			Getdamaged ();
		}

	}
}
