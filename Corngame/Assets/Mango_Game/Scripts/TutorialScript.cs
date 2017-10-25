using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

	int currentIndex;

	public static bool showing;

	public List<GameObject> pages;

	void Start() {
	
		currentIndex = 0;
		showing = true;
		ShowPage ();

		if (BGMScript.Instance != null) {
			if(SceneManager.GetActiveScene().name == "BugAway")
			BGMScript.Instance.PlayBugAwayBGM ();
		}

		Time.timeScale = 0;
	}

	void Update() {

//		#if UNITY_EDITOR
//		if(Input.GetMouseButtonDown(0))
//			NextPage();
//		#endif
	}

	public void NextPage() {

		currentIndex++;

		SFXScript.Instance.PlayOverallSFX ("tap");

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

		Time.timeScale = 1;
	}
}
