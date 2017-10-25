using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGTreeScript : MonoBehaviour {
	
	[SerializeField] GameObject mangoes;
	[SerializeField] GameObject speedUp;
	[SerializeField] GameObject gameOverCanvas;
	[SerializeField] Text_Reader_Script TriviaText;

	[SerializeField] Animator treeAC;
	[SerializeField] Animator ramonAC;

	[SerializeField] Transform start;
	[SerializeField] Transform stage;
	[SerializeField] Transform end;

	[SerializeField] MeterScript meter;

	[SerializeField] Text ui;
	[SerializeField] Text scoreUI;
	[SerializeField] Text finalScoreUI;

	[SerializeField] SpriteRenderer gestureSpriteRenderer;

	[SerializeField] BackgroundScript background;

	public List<string> gestures;
	string currentGesture;

	public List<Sprite> gestureSprites;

	public float interval;
	public float normalTimer;
	public float hardTimer;

	public float easyTimeScale;
	public float normalTimeScale;
	public float hardTimeScale;

	public int easyLimit;
	public int normalLimit;
	int hardLimit;

	int score;

	int previousGestureIndex = -1;
	int currentGestureIndex = -1;
	int currentLimit;

	bool sprayable;
	bool sprayed;

	void Start () {
		
		SimpleGesture.On4AxisSwipeUp (SwipeUp);
		SimpleGesture.On4AxisSwipeDown (SwipeDown);
		SimpleGesture.On4AxisSwipeRight (SwipeRight);
		SimpleGesture.On4AxisSwipeLeft (SwipeLeft);
		SimpleGesture.OnCircle (Circle);
		SimpleGesture.OnZigZag (Zigzag);
		SimpleGesture.WhileStretching (ZoomOut);
		SimpleGesture.WhilePinching (ZoomIn);
		SimpleGesture.WhileTwisting (Twist);
		StartCoroutine (Loop ());
		StartCoroutine (IncreaseDifficulty ());

		score = 0;
		scoreUI.text = "0";

		hardLimit = gestures.Count;

		currentLimit = easyLimit;
//		currentLimit = hardLimit;

		SoundUIScript.Instance.Show (true);
		SoundUIScript.Instance.Portrait ();

		speedUp.gameObject.SetActive (false);
		gameOverCanvas.SetActive (false);

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

//		Debug.Log ("CHOOSE GESTURE");

		if (previousGestureIndex == -1) {

//			Debug.Log ("Setting");

			currentGestureIndex = Random.Range (0, currentLimit);
			previousGestureIndex = currentGestureIndex;

		} else {
		
			currentGestureIndex = Random.Range (0, currentLimit);

//			Debug.Log (previousGestureIndex + " : " + currentGestureIndex);

			while (previousGestureIndex == currentGestureIndex) {

				currentGestureIndex = Random.Range (0, currentLimit);
			}

			previousGestureIndex = currentGestureIndex;
		}

		currentGesture = gestures [currentGestureIndex];
		gestureSpriteRenderer.sprite = gestureSprites [currentGestureIndex];

		SetText (currentGesture);
	}

	void GetSprayed() {

		if (!sprayable || sprayed || meter.gameOver)
			return;

		background.Animate ();
		SFXScript.Instance.PlayMangoSpray ();
		sprayed = true;
		treeAC.SetTrigger ("spray");
		ramonAC.SetTrigger ("spray");
		meter.OnSpray ();
		AddScore ();
	}

	void ShowMangoes() {

		SFXScript.Instance.CornGamePlaySFX ("blop");
		mangoes.SetActive (true);
	}

	void SetText(string s) {

		ui.text = s;
	}

	IEnumerator Loop() {

		yield return new WaitForEndOfFrame ();

		BGMScript.Instance.PlayMangoBGM ();

		yield return new WaitUntil (() => !TutorialScript.showing);

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

//		Debug.Log ("game over");

		Time.timeScale = 1;

		StopAllCoroutines ();

		finalScoreUI.text = score.ToString ();
		gameOverCanvas.SetActive (true);
		TriviaText.SetTrivia ();
	}

	IEnumerator IncreaseDifficulty() {

		currentLimit = easyLimit;
		Time.timeScale = easyTimeScale;

		yield return new WaitForSeconds (normalTimer);

		currentLimit = normalLimit;
		Time.timeScale = normalTimeScale;
		speedUp.gameObject.SetActive (true);

		yield return new WaitForSeconds (hardTimer);

		currentLimit = hardLimit;
		Time.timeScale = hardTimeScale;
		speedUp.gameObject.SetActive (true);
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

	void SwipeLeft() {

		if (!currentGesture.Equals ("swipeleft"))
			return;

		GetSprayed ();
	}

	void SwipeRight() {

		if (!currentGesture.Equals ("swiperight"))
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

	void Twist() {

		if (!currentGesture.Equals ("twist"))
			return;

		GetSprayed ();
	}
}
