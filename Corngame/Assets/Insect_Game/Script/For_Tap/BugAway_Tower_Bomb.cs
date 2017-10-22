using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_Bomb : BugAway_Tower_BASEclass {

	bool exploding;

	public GameObject hitBox;

	public SpriteRenderer sr;

	public Animator bombAC;

	public GridScriptTAP grid;

	void Start () {
		
	}

	void OnEnable() {

		exploding = false;
		hitBox.SetActive (false);

		sr.enabled = true;
	}

	void Update() {


	}

	public override void StartAttacking() {

		// nothing
	}

	public override void StopAttacking() {

		// nothing
	}

	public void Explode() {

//		Debug.Log ("IM CLICKED");

		if (exploding || !InsectGameControllerTAP.Instance.plantingDone)
			return;

//		Debug.Log ("START EXPLOSION? YES");

		bombAC.SetTrigger ("explode");
	}

	public void StartExploding() {
	
		StartCoroutine (GonnaExplode ());	
	}

	IEnumerator GonnaExplode() {

		sr.enabled = false;

		hitBox.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.25f);

		grid.Restore_Grid ();

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D c) {

		if (exploding)
			return;

		if (c.CompareTag ("Enemy")) {
		
			Explode ();
		}
	}
}
