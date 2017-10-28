using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointScript : MonoBehaviour {

	public bool gameOver;
	[SerializeField] Text_Reader_Script TextReader;

	void Start() {

		gameOver = false;
	}

	void OnTriggerEnter2D(Collider2D c) {
	
		if (c.CompareTag ("Enemy")) {

			InsectGameControllerTAP.Instance.gameOver = true;
			TextReader.SetTrivia ();
		}
	}
}
