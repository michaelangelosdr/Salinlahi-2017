using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAway_Tower_Bomb : BugAway_Tower_BASEclass {

	bool exploding;

	[SerializeField] GameObject hitBox;

	void Start () {
		
	}

	void OnEnable() {

		exploding = false;
		hitBox.SetActive (false);
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

		Debug.Log ("IM CLICKED");

		if (exploding || !InsectGameControllerTAP.Instance.plantingDone)
			return;

//		Debug.Log ("START EXPLOSION? YES");

		StartCoroutine (GonnaExplode ());
	}

	IEnumerator GonnaExplode() {

//		Debug.Log ("Exploding");

		yield return new WaitForSeconds (1f);

//		Debug.Log ("NOW");

		hitBox.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.25f);

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D c) {

		if (exploding)
			return;

		if (c.CompareTag ("Enemy")) {
		
			StartCoroutine (GonnaExplode ());
		}
	}
}
