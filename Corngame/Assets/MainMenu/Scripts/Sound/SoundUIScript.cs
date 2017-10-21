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

		settingsShown = !settingsShown;
		//Testtest
		//This script makes all game objecs
		try{
			GameObject.Find("Corn_Field").GetComponent<Corn_Controller>().Corns_Tappable(!settingsShown);
            GameObject.Find("Main Camera").GetComponent<timer_script>().TimerPauser(!settingsShown);
        }
		catch {
			Debug.LogError ("ERROR NO CORN FIELD HERE, CAN CONTINUE THO");
		}

		settingsPrefab.SetActive (settingsShown);
	}
}
