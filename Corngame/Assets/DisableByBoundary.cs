using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByBoundary : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c) {
	
		c.gameObject.SetActive (false);
	} 
}
