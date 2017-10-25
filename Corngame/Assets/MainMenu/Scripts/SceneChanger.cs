using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public string sceneName;

	public void ChangeScene() {
	
		if (string.IsNullOrEmpty (sceneName))
			return;

		if (sceneName.Equals ("exit")) {
		
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			return;
			#endif

			Application.Quit ();
		}

		SceneManager.LoadScene (sceneName);
	}
}
