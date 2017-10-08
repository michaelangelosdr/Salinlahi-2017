using System.Collections;
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

	[SerializeField] MeterScript meter;

	[SerializeField] Text ui;
	[SerializeField] Text scoreUI;

	public List<string> gestures;
	string currentGesture;

	public float interval;
	public float normalTimer;
	public float hardTimer;

	public float easyTimeScale;
	public float normalTimeScale;
	public float hardTimeScale;

	int score;

	int currentLimit;
	int easyLimit;
	int normalLimit;
	int hardLimit;

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
		StartCoroutine (IncreaseDifficulty ());

		score = 0;
		scoreUI.text = "0";

		easyLimit = 2;
		normalLimit = 4;
		hardLimit = gestures.Count;

		currentLimit = hardLimit;

		Time.timeScale = 1;
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

		meter.paused = true;

		ChooseGesture ();
	}

	void ChooseGesture() {

		currentGesture = gestures [Random.Range (0, gestures.Count)];

		SetText (currentGesture);
	}

	void GetSprayed() {

		if (!sprayable || sprayed)
			return;

		sprayed = true;
		treeAC.SetTrigger ("spray");
		ramonAC.SetTrigger ("spray");
		meter.OnSpray ();
		AddScore ();
	}

	void ShowMangoes() {

		mangoes.SetActive (true);
	}

	void SetText(string s) {

		ui.text = s;
	}

	IEnumerator Loop() {

		float timeElapsed;

		while (!meter.gameOver) {

			Reset ();

			transform.position = start.position;

			timeElapsed = 0;

			while (timeElapsed <= interval) {
			
				transform.position = Vector3.Lerp (start.position, stage.position, timeElapsed / interval);
				timeElapsed += Time.deltaTime;

				yield return null;
			}

			transform.position = stage.position;

			meter.Reset ();

			sprayable = true;

			while (!sprayed) {

				if (meter.gameOver)
					break;

				yield return null;
			}

			if (meter.gameOver)
				break;
				
			yield return new WaitForSeconds (1);

			timeElapsed = 0;

			while (timeElapsed <= interval) {

				transform.position = Vector3.Lerp (stage.position, end.position, timeElapsed / interval);
				timeElapsed += Time.deltaTime;

				yield return null;
			}

			transform.position = end.position;
		}

		Debug.Log ("game over");

		Time.timeScale = 1;
	}

	IEnumerator IncreaseDifficulty() {

		currentLimit = easyLimit;
		Time.timeScale = easyTimeScale;

		yield return new WaitForSeconds (normalTimer);

		currentLimit = normalLimit;
		Time.timeScale = normalTimeScale;

		yield return new WaitForSeconds (hardTimer);

		currentLimit = hardLimit;
		Time.timeScale = hardTimeScale;
	}

	void AddScore() {

		score++;
		scoreUI.text = score.ToString ();
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
