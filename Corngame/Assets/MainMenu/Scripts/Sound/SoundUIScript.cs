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

	bool settingsShown;

	void Start () {
		
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

	public void ShowSettingsPrefab() {

		Debug.Log ("Bruh");

		settingsShown = !settingsShown;

		settingsPrefab.SetActive (settingsShown);
	}
}
