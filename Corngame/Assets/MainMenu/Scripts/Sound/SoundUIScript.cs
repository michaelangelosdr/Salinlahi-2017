using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUIScript : MonoBehaviour {

	private static SoundUIScript instance;

	public static SoundUIScript Instance {

		get { 

			return instance;
		}
	}

	[SerializeField] GameObject settingsPrefab;
	[SerializeField] GameObject settingsButton;

	bool settingsShown;

	float previousTimeScale = 0;

	void Awake () {
		
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);

		settingsShown = false;
		settingsPrefab.SetActive (false);

		Debug.Log ("Sound UI Initialized");
	}
	
	public void Show(bool b) {

		gameObject.SetActive (b);
	}

	public void Landscape() {

		RectTransform buttonRect = settingsButton.GetComponent<RectTransform> ();

		buttonRect.anchoredPosition = new Vector2 (-5, 10);
		buttonRect.rotation = Quaternion.Euler (0, 0, 90);
		buttonRect.anchorMin = new Vector2 (1, 0);
		buttonRect.anchorMax = new Vector2 (1, 0);
		buttonRect.pivot = Vector2.zero;

		RectTransform overlayRect = settingsPrefab.GetComponent<RectTransform> ();

		overlayRect.anchoredPosition = Vector2.zero;
		overlayRect.rotation = Quaternion.Euler (0, 0, -90);
		overlayRect.anchorMin = new Vector2 (0.5f, 0.5f);
		overlayRect.anchorMax = new Vector2 (0.5f, 0.5f);
		overlayRect.pivot = new Vector2 (0.5f, 0.5f);
	}

	public void Portrait() {

		RectTransform buttonRect = settingsButton.GetComponent<RectTransform> ();

		buttonRect.anchoredPosition = new Vector2 (-5, -10);
		buttonRect.rotation = Quaternion.Euler (0, 0, 0);
		buttonRect.anchorMin = new Vector2 (1, 1);
		buttonRect.anchorMax = new Vector2 (1, 1);
		buttonRect.pivot = new Vector2 (1, 1);

		RectTransform overlayRect = settingsPrefab.GetComponent<RectTransform> ();

		overlayRect.anchoredPosition = Vector2.zero;
		overlayRect.rotation = Quaternion.Euler (0, 0, 0);
		overlayRect.anchorMin = new Vector2 (0.5f, 0.5f);
		overlayRect.anchorMax = new Vector2 (0.5f, 0.5f);
		overlayRect.pivot = new Vector2 (0.5f, 0.5f);
	}

	public void ShowSettingsPrefab() {

		settingsShown = !settingsShown;
		//Testtest
		//This script makes all game objecs

		bool corngame = false;
		bool mangogame = false;

		try{           
			
            GameObject.Find("Corn_Field").GetComponent<Corn_Controller>().Corns_Tappable(!settingsShown);
            GameObject.Find("Main Camera").GetComponent<timer_script>().TimerPauser(!settingsShown);          
			corngame = true;
        }
		catch {
			Debug.LogError ("This is not Corngame lol but pls continue");
		}

        try { 

			GameObject.Find("Meter Container").GetComponent<MeterScript>().paused = settingsShown;
			mangogame = false;
		}
        catch { Debug.LogError("No Meter Container here lol"); }

		if (!corngame && !mangogame) {

			if (settingsShown) {
			
				previousTimeScale = Time.timeScale;
				Time.timeScale = 0;
			} else {
			
				Time.timeScale = previousTimeScale;
			}
		}

		settingsPrefab.SetActive (settingsShown);
	}
}
