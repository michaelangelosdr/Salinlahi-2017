using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAwayBulletBase : MonoBehaviour {

	public float speed;
	
	void FixedUpdate () {

		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D c) {
		
		if (c.CompareTag ("Enemy"))
			gameObject.SetActive (false);
	}
}
