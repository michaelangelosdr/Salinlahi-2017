using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGScript : MonoBehaviour {

	List<SpriteRenderer> spriteRenderers;

	void Awake () {

		spriteRenderers = new List<SpriteRenderer> ();

		foreach (Transform t in transform)
			spriteRenderers.Add (t.GetComponent<SpriteRenderer> ());
	}

	public void ShowAll(bool b) {
	
		foreach (SpriteRenderer sr in spriteRenderers)
			sr.color = b ? Color.white : Color.clear;
	}

	public void Fade(bool fadeIn, float transitionSpeed) {

		StartCoroutine (Fading (fadeIn, transitionSpeed));
	}

	IEnumerator Fading(bool fadeIn, float transitionSpeed) {


		Color startColor = fadeIn ? Color.clear : Color.white;
		Color endColor = fadeIn ? Color.white : Color.clear;

		float timeElapsed = 0;

		while (timeElapsed < transitionSpeed) {
		
			foreach (SpriteRenderer sr in spriteRenderers)
				sr.color = Color.Lerp (startColor, endColor, timeElapsed / transitionSpeed);

			timeElapsed += Time.deltaTime;
			yield return null;
		}

		foreach (SpriteRenderer sr in spriteRenderers)
			sr.color = endColor;
	}
}
