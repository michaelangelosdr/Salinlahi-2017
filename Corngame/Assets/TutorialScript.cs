using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

	int currentIndex;

	public static bool showing;

	public List<GameObject> pages;

	void Start() {
	
		currentIndex = 0;
		showing = true;
		ShowPage ();
	}

	void Update() {

		if (Input.GetMouseButtonDown (0)) {
		
			currentIndex++;

			if (currentIndex >= pages.Count) {
			
				showing = false;
				gameObject.SetActive (false);
			} else {

				ShowPage ();
			}
		}
	}

	void ShowPage() {

		foreach (GameObject go in pages)
			go.SetActive (false);

		pages [currentIndex].SetActive (true);
	}
}
