using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsectGameController : MonoBehaviour {

	public TowerDragScript sampleTower;

	public int indexChosen;

	public bool dragging;


	public Vector3 offset;

	void Start () {
	
		Debug.Log ("Bruh");

		offset = Vector3.forward * 5;
	}

	void Update() {

		if (dragging) {

			sampleTower.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + offset;
		}
	}

	public void OnTowerChosen(int index) {
		Debug.Log ("pota gumana ka");
		indexChosen = index;
		sampleTower.gameObject.SetActive (true);
		sampleTower.dragging = dragging = true;
		sampleTower.grid = null;
	}

	public void Release() {

		Debug.Log ("Why?");
		dragging = false;

		sampleTower.OnRelease ();
	}
}
