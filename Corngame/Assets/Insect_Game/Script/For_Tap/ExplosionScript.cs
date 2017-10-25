using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c) {

		if (c.CompareTag ("Enemy")) {
		
			if (!c.GetComponent<BossBugScript> ())
				c.GetComponent<Bugaway_Enemies_BaseClass> ().KillBug (c.gameObject);
			else
				c.GetComponent<BossBugScript> ().Getdamaged ();
		}
	}
}
