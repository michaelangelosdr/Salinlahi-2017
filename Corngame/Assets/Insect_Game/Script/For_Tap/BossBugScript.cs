using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBugScript : Bugaway_Enemies_BaseClass {

	public bool killed;

	public List<Transform> rows;

	public float rowChangingSpeed;

	int currentRow;

	Rigidbody2D rb;

	public Animator ac;

	public BugAway_Tower_BASEclass towerContact;

	void OnEnable () {
		
		Health = 10 + InsectGameControllerTAP.Instance.HealthIncrement; 
		speed = 1 + InsectGameControllerTAP.Instance.SpeedIncrement;
		Damage = 1;

		killed = false;

		currentRow = Random.Range (0, rows.Count);

		transform.position = rows[currentRow].position;

		rb = GetComponent<Rigidbody2D> ();

		rb.velocity = Vector2.up * speed;

		if(SFXScript.Instance)
			SFXScript.Instance.BugAwayPlaySFX ("Boss_BugSpawn");

		StartCoroutine (Moving ());
	}

	public void Move() {

		rb.velocity = Vector2.up * speed;
	}

	public void Stop() {

		rb.velocity = Vector2.zero;
	}

	IEnumerator Moving() {

		while (!killed) {
		
			Debug.Log ("moving");

			yield return new WaitForSeconds (Random.Range (1f, 2f));

			yield return ChangePosition ();
		}
	}

	IEnumerator ChangePosition() {

		int newRow = Random.Range (0, rows.Count);

		while (newRow == currentRow) {
		
			newRow = Random.Range (0, rows.Count);
		}

		currentRow = newRow;

		float startX = transform.position.x;
		float endX = rows[newRow].position.x;

		float timeElapsed = 0;

		while (timeElapsed < rowChangingSpeed) {
		
			yield return new WaitUntil (() => rb.velocity.magnitude > 0);

			transform.position = new Vector3 (Mathf.Lerp (startX, endX, timeElapsed / rowChangingSpeed), transform.position.y, transform.position.z);
			timeElapsed += Time.deltaTime;

			yield return null;
		}

		transform.position = new Vector3 (endX, transform.position.y, transform.position.z);
	}

	public override void KillBug(GameObject thisbug) {
	
		killed = true;
		BGMScript.Instance.PlayBugAwayBGM ();
		base.KillBug (thisbug);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Endpoint") {
			KillBug (this.gameObject);
		}

		if (col.CompareTag("row1_tower") || col.CompareTag("row2_tower") || col.CompareTag("row3_tower"))
		{

			if (!col.GetComponent<BugAway_Tower_Bomb> ()) {
			
				towerContact = col.GetComponent<BugAway_Tower_BASEclass> ();
				ac.SetTrigger ("contact");
				SFXScript.Instance.BugAwayPlaySFX ("Boss_BugSpawn");
			}
		}
		if (col.CompareTag ("Bullet")) {
			Getdamaged ();
		}
	}

	public void KillTower() {

		if (towerContact)
			towerContact.Die ();
	}
}
