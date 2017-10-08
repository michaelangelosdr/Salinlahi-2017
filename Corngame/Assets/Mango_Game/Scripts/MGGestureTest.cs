using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGGestureTest : MonoBehaviour {

	[SerializeField] Text ui;
	[SerializeField] GameObject touchEffect1;
	[SerializeField] GameObject touchEffect2;

	Touch currentTouch1;
	Touch currentTouch2;

	void Awake () {
		
		touchEffect1.SetActive (false);
		touchEffect2.SetActive (false);
	}

	void Update() {
		
		#if UNITY_EDITOR

		if(Input.mousePresent) {

			touchEffect1.SetActive(true);
			touchEffect1.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		} else {

			touchEffect1.SetActive(false);
		}

		return;

		#endif

		if (Input.touches.Length <= 0)
			return;

		currentTouch1 = Input.touches[0];

		if (currentTouch1.phase == TouchPhase.Began) {

			touchEffect1.SetActive (false);
			touchEffect1.SetActive (true);
			touchEffect1.transform.position = Camera.main.ScreenToWorldPoint (currentTouch1.position);
		}

		if (currentTouch1.phase == TouchPhase.Moved) {

			touchEffect1.transform.position = Camera.main.ScreenToWorldPoint (currentTouch1.position);
		}

		if (Input.touches.Length <= 1)
			return;

		currentTouch2 = Input.touches[1];

		if (currentTouch2.phase == TouchPhase.Began) {

			touchEffect2.SetActive (false);
			touchEffect2.SetActive (true);
			touchEffect2.transform.position = Camera.main.ScreenToWorldPoint (currentTouch2.position);
		}

		if (currentTouch2.phase == TouchPhase.Moved) {

			touchEffect2.transform.position = Camera.main.ScreenToWorldPoint (currentTouch2.position);
		}
	}
}
