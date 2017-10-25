using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour {

	public string nextScene;
	[SerializeField] GameObject DarkOverlay;
	[SerializeField] Overlay_Fade_Script fadescript;



	void Update () {
		
		#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
			StartCoroutine (LoadNext ());
		#endif

		if (Input.touches.Length > 0) {
		
			if (Input.GetTouch (0).phase == TouchPhase.Began) 
			{

				StartCoroutine (LoadNext ());
				//return;
			}
		}

		SoundUIScript.Instance.Show (false);
		SoundUIScript.Instance.Portrait ();
	}


	IEnumerator LoadNext()
	{

		SFXScript.Instance.PlayTransition ();
		float fadetime = fadescript.BeginFade (1);
		fadescript.StartFade ();
		yield return new WaitForSeconds (fadetime);
		SceneManager.LoadScene (nextScene);


	}
}
