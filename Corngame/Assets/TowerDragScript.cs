using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDragScript : MonoBehaviour {

	public bool dragging;

	public GridScript grid;

	public SpriteRenderer sr;

	void OnEnable () {

		dragging = true;
		grid = null;
	}

	public Sprite GetSprite() {
	
		return sr.sprite;
	}

	public void OnRelease() {

		dragging = false;

		Debug.Log ("released");

		if (grid == null)
			gameObject.SetActive (false);
		else
			transform.position = grid.transform.position;
	}

	void OnTriggerEnter2D(Collider2D c) {

		if (c.GetComponent<GridScript> () != null) {
		
			grid = c.GetComponent<GridScript> ();
			Debug.Log ("griid");
		} else {
		
			grid = null;
		}
	}

	void OnTriggerExit2D(Collider2D c) {

		if (c.GetComponent<GridScript> () != null) {

			grid = null;
		}
	}
}
