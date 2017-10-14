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

		#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
			NextPage();
		#endif
	}

	public void NextPage() {

		currentIndex++;

		if (currentIndex >= pages.Count)
			CloseTutorial ();
		else
			ShowPage ();
	}

	void ShowPage() {

		foreach (GameObject go in pages)
			go.SetActive (false);

		pages [currentIndex].SetActive (true);
	}

	public void CloseTutorial() {

		showing = false;
		gameObject.SetActive (false);
	}
}
