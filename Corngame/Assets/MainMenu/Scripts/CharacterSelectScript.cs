using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScript : MonoBehaviour {

	int currentCharacterIndex = 0;

	public List<SceneChanger> characters;

	public void Start() {
	
		SoundUIScript.Instance.Show (false);
		SoundUIScript.Instance.Portrait ();

		currentCharacterIndex = 0;

		UpdateCanvas ();
	}

	public void Navigate(int dir) {

		currentCharacterIndex -= dir;

		if (currentCharacterIndex < 0)
			currentCharacterIndex = characters.Count-1;
		else if (currentCharacterIndex >= characters.Count)
			currentCharacterIndex = 0;

		UpdateCanvas ();
	}

	public void UpdateCanvas() {

		foreach (SceneChanger sc in characters)
			sc.gameObject.SetActive (false);

		characters [currentCharacterIndex].gameObject.SetActive (true);
	}

	public void GoToScene() {
		
		characters [currentCharacterIndex].ChangeScene ();
	}
}
