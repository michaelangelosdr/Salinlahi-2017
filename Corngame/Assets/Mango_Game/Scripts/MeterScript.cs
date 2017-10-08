using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour {

	public float secondsToTake;
	public float minimumSeconds;
	public float reductionRate;
	public float currentTime;

	public bool paused;

	public Image fill;

	void Start() {

		Reset ();
	}

	void Update() {

		if (currentTime > 0) {

			if (!paused)
				SetCurrentTime (currentTime - Time.deltaTime);
		} else {

			SetCurrentTime (0);
			Debug.Log ("Game Over");
		}
	}

	public void Reset() {

		SetCurrentTime (secondsToTake);

		paused = false;
	}

	void SetCurrentTime(float time) {

		currentTime = time;
		UpdateFill ();
	}

	public void OnSpray() {

		paused = true;
		ReduceSecondsToTake ();

		StartCoroutine (FillEmUp ());
	}

	IEnumerator FillEmUp() {

		float totalTime = 2f;
		float restTime = 1.75f;
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

	void ReduceSecondsToTake() {

		secondsToTake -= reductionRate;

		if (secondsToTake < minimumSeconds) {
		
			secondsToTake = minimumSeconds;
		}
	}

	void UpdateFill() {
	
		fill.transform.localScale = new Vector3 (currentTime / secondsToTake, 1, 1);
	}
}
