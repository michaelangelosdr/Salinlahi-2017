using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour {

	public string nextScene;

	void Update () {
		
		#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
			SceneManager.LoadScene(nextScene);
		#endif

		if (Input.touches.Length > 0) {
		
			if (Input.GetTouch (0).phase == TouchPhase.Began) {

				SceneManager.LoadScene (nextScene);
				SoundUIScript.Instance.Show (true);
			} else {
			
				SoundUIScript.Instance.Show (false);
			}
		}
	}
}
