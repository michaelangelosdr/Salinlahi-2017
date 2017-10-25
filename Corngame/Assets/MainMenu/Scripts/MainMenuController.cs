using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public Transform cameraPointStart;
	public Transform cameraPointEnd;

	public float panTime;
	public float transitionTime;
	public float transitionSpeed;

	public GameObject camera;

	public List<MainMenuBGScript> bgs;

	public Image overlay;

	int currentIndex;

	void Start() {

		currentIndex = Random.Range (0, bgs.Count);

		foreach (MainMenuBGScript bg in bgs) {
		
			bg.gameObject.SetActive (true);
			bg.ShowAll (false);
		}

		bgs [currentIndex].ShowAll (true);

		SoundUIScript.Instance.Show (true);
		SoundUIScript.Instance.Portrait ();

		BGMScript.Instance.PlayMainMenu ();

		StartCoroutine (OverlayFadeOut ());
		StartCoroutine (StartPanning ());
		StartCoroutine (StartFading ());
	}

	IEnumerator StartPanning() {
		
		Vector3 startPos = cameraPointStart.position;
		Vector3 endPos = cameraPointEnd.position;
		float timeElapsed = 0;

		camera.transform.position = startPos;

		while (true) {

			yield return MoveCamera (startPos, endPos);
			yield return MoveCamera (endPos, startPos);
		}
	}

	IEnumerator MoveCamera(Vector3 startPos, Vector3 endPos) {

		float timeElapsed = 0;

		while (timeElapsed < panTime) {

			camera.transform.position = Vector3.Lerp (startPos, endPos, timeElapsed / panTime);

			timeElapsed += Time.deltaTime;
			yield return null;
		}

		camera.transform.position = endPos;
	}

	IEnumerator StartFading() {
		
		while (true) {
		
			yield return new WaitForSeconds (transitionTime);

			bgs [currentIndex++].Fade (false, transitionSpeed);

			if (currentIndex >= bgs.Count)
				currentIndex = 0;
			
			bgs [currentIndex].Fade (true, transitionSpeed);
		}
	}

	IEnumerator OverlayFadeOut() {
		
		float timeElapsed = 0;

		Color startColor = Color.black;
		Color endColor = Color.clear;

		while (timeElapsed < 1) {
		
			overlay.color = Color.Lerp (startColor, endColor, timeElapsed / 1);

			timeElapsed += Time.deltaTime;
			yield return null;
		}

		overlay.color = endColor;
	}
}
