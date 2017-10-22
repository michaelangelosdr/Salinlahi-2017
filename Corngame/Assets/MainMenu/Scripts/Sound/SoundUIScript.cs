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

	float previousTimeScale = 0;

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
