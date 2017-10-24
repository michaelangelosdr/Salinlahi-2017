using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_PunchingSack : BugAway_Tower_BASEclass {

    private void Awake()
    {
        health = 3;
        towerCost = 20;
        towerName = "Punching Sack";
        attackSpeed = 0;
    }

	void OnTriggerEnter2D(Collider2D c) {

		if (c.GetComponent<Bugaway_Enemies_BaseClass> ())
			ac.SetTrigger ("defend");
	}
}
