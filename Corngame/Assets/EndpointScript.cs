using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointScript : MonoBehaviour {

	public bool gameOver;

	void Start() {

		gameOver = false;
	}

	void OnTriggerEnter2D(Collider2D c) {
	
		if (c.CompareTag ("Enemy"))
			gameOver = true;
	}
}
