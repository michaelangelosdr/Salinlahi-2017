using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBugScript : Bugaway_Enemies_BaseClass {

	public bool killed;

	public List<Transform> rows;

	public float rowChangingSpeed;

	int currentRow;

	Rigidbody2D rb;

	void OnEnable () {

		killed = false;

		currentRow = Random.Range (0, rows.Count);

		transform.position = rows[currentRow].position;

		rb = GetComponent<Rigidbody2D> ();

		rb.velocity = Vector2.up * speed;

		StartCoroutine (Moving ());
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
		
			transform.position = new Vector3 (Mathf.Lerp (startX, endX, timeElapsed / rowChangingSpeed), transform.position.y, transform.position.z);
			timeElapsed += Time.deltaTime;

			yield return null;
		}

		transform.position = new Vector3 (endX, transform.position.y, transform.position.z);
	}

	public override void KillBug(GameObject thisbug) {
	
		killed = true;
		base.KillBug (thisbug);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Endpoint") {
			KillBug (this.gameObject);
		}

		if (col.CompareTag("row1_tower") || col.CompareTag("row2_tower") || col.CompareTag("row3_tower"))
		{
			col.GetComponent<BugAway_Tower_BASEclass>().Damage_This_Tower();
			Getdamaged ();
		}
		if (col.CompareTag ("Bullet")) {
			Getdamaged ();
		}
	}
}
