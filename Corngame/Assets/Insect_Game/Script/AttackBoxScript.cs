using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxScript : MonoBehaviour {

	BugAway_Tower_BASEclass tower;

	void Start() {
		
		tower = GetComponentInParent<BugAway_Tower_BASEclass> ();
	}

	void OnTriggerEnter2D(Collider2D c) {

		if (!c.CompareTag ("Enemy"))
			return;

		tower.StartAttacking ();
	}

	void OnTriggerExit2D(Collider2D c) {
	
		tower.StopAttacking ();
	}
}
