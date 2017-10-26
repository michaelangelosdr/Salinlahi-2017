using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour {

	public Transform credits;

	public float bottomLimit;
	public float speed;

	public bool speedup;

	void Awake() {

		speedup = false;
	}

	void Update () {

		if (credits.position.y >= bottomLimit) {
		
			credits.position = Vector3.up * bottomLimit;
			return;
		}

		if (speedup)
			credits.Translate (Vector3.up * speed * 4 * Time.deltaTime);
		else
			credits.Translate (Vector3.up * speed * Time.deltaTime);
	}

	public void AdjustSpeed() {
	
		Debug.Log ("bruh");
		speedup = !speedup;
	}

	public void ReturnToMainMenu() {

		SceneManager.LoadScene ("Main_Menu");
	}
}
