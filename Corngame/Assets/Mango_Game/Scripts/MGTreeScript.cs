﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGTreeScript : MonoBehaviour {
	
	[SerializeField] GameObject mangoes;
	[SerializeField] Animator treeAC;
	[SerializeField] Animator ramonAC;

	[SerializeField] Transform start;
	[SerializeField] Transform stage;
	[SerializeField] Transform end;

	[SerializeField] Text ui;

	public List<string> gestures;
	string currentGesture;

	public float interval;

	bool sprayable;
	bool sprayed;

	void Awake () {

		SimpleGesture.On4AxisSwipeUp (SwipeUp);
		SimpleGesture.On4AxisSwipeDown (SwipeDown);
		SimpleGesture.OnCircle (Circle);
		SimpleGesture.OnZigZag (Zigzag);
		SimpleGesture.WhileStretching (ZoomOut);
		SimpleGesture.WhilePinching (ZoomIn);
		StartCoroutine (Loop ());
	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.S) && !sprayed)
			GetSprayed ();
	}

	void Reset() {

		sprayable = false;
		sprayed = false;
		mangoes.SetActive (false);
		treeAC.SetTrigger ("reset");

		ChooseGesture ();
	}

	void GetSprayed() {

		if (!sprayable || sprayed)
			return;

		sprayed = true;
		treeAC.SetTrigger ("spray");
		ramonAC.SetTrigger ("spray");
	}

	void ShowMangoes() {

		mangoes.SetActive (true);
	}

	void ChooseGesture() {
	
		currentGesture = gestures [Random.Range (0, gestures.Count)];

		SetText (currentGesture);
	}

	void SetText(string s) {

		ui.text = s;
	}

	IEnumerator Loop() {

		float timeElapsed;

		while (true) {

			Reset ();

			transform.position = start.position;

			timeElapsed = 0;

			while (timeElapsed <= interval) {
			
				transform.position = Vector3.Lerp (start.position, stage.position, timeElapsed / interval);
				timeElapsed += Time.deltaTime;

				yield return null;
			}

			transform.position = stage.position;

			sprayable = true;

			yield return new WaitUntil (() => mangoes.activeInHierarchy);

			yield return new WaitForSeconds (1);

			timeElapsed = 0;

			while (timeElapsed <= interval) {

				transform.position = Vector3.Lerp (stage.position, end.position, timeElapsed / interval);
				timeElapsed += Time.deltaTime;

				yield return null;
			}

			transform.position = end.position;
		}
	}

	void SwipeUp() {
	
		if (!currentGesture.Equals ("swipeup"))
			return;

		GetSprayed ();
	}

	void SwipeDown() {

		if (!currentGesture.Equals ("swipedown"))
			return;

		GetSprayed ();
	}

	void Circle(GestureInfoCircle g) {

		if (!currentGesture.Equals ("circle"))
			return;

		GetSprayed ();
	}

	void Zigzag(GestureInfoZigZag g) {

		if (!currentGesture.Equals ("zigzag"))
			return;

		GetSprayed ();
	}

	void ZoomIn() {

		if (!currentGesture.Equals ("zoomin"))
			return;

		GetSprayed ();
	}

	void ZoomOut() {

		if (!currentGesture.Equals ("zoomout"))
			return;

		GetSprayed ();
	}
}
