using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public string sceneName;

	public void ChangeScene() {
	
		if (string.IsNullOrEmpty (sceneName))
			return;

		SceneManager.LoadScene (sceneName);
	}
}
