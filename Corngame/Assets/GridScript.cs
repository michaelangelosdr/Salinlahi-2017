using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {

	public SpriteRenderer preview;

	TowerDragScript tower;

	void Update() {

		if (tower != null) {
		
			if (tower.dragging) {

				preview.gameObject.SetActive (true);
			} else {

				preview.gameObject.SetActive (false);	
			}
		} else {

			preview.gameObject.SetActive (true);
		}
	}

	public void RemoveTower() {

		tower = null;
		preview.sprite = null;
	}

	public void ChangePreviewSprite() {

		preview.sprite = tower.GetSprite ();
	}

	void OnTriggerEnter2D(Collider2D c) {

		if (c.GetComponent<TowerDragScript> () != null) {

			tower = c.GetComponent<TowerDragScript> ();
			ChangePreviewSprite ();
		} else {
		
			tower = null;
		}
	}

	void OnTriggerExit2D(Collider2D c) {

		if (c.GetComponent<TowerDragScript> () != null) {

			Debug.Log ("Bruh");
			RemoveTower ();
		}
	}
		
}
