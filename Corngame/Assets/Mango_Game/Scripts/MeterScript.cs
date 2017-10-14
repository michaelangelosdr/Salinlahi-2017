using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour {

	public float secondsToTake;
	public float currentTime;

	public bool paused;
	public bool gameOver;

	public Image fill;

	void Start() {

		gameOver = false;
		UpdateFill ();
	}

	void Update() {

		if (TutorialScript.showing)
			return;

		if (currentTime > 0) {

			if (!paused)
				SetCurrentTime (currentTime - Time.deltaTime);
		} else {

			SetCurrentTime (0);
			gameOver = true;
			Time.timeScale = 1;
		}
	}

	public void Reset() {

		SetCurrentTime (secondsToTake);

		paused = false;
	}

	void SetCurrentTime(float time) {
		
		currentTime = time;

		currentTime = Mathf.Clamp (currentTime, 0, secondsToTake);

		UpdateFill ();
	}

	public void OnSpray() {

		paused = true;
		StartCoroutine (FillEmUp ());
	}

	IEnumerator FillEmUp() {

		float totalTime = 1.5f;
		float restTime = 1f;
		float goTime = totalTime - restTime;

		yield return new WaitForSeconds (restTime);

		float timeElapsed = 0;

		float startTime = currentTime;
		float endTime = secondsToTake;

		while (timeElapsed < goTime) {
	
			SetCurrentTime(Mathf.Lerp (startTime, endTime, timeElapsed / goTime));

			timeElapsed += Time.deltaTime;
			yield return null;
		}

		SetCurrentTime (endTime);
		UpdateFill ();
	}

	void UpdateFill() {
	
		fill.transform.localScale = new Vector3 (currentTime / secondsToTake, 1, 1);
	}
}
