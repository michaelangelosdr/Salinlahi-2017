using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour {
	
	private static SFXScript instance;

	public static SFXScript Instance {

		get { 

			return instance;
		}
	}

	AudioSource audioSource;
	public List<AudioClip> CorngameSFXs;


	void Start() {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClip(AudioClip newClip,float volume = 1.0f) {

		audioSource.volume = volume;
		audioSource.PlayOneShot (newClip);
	}

	public void CornGamePlaySFX(string nameOfSFX)
	{
		switch (nameOfSFX) {
		case "blop":
			PlayClip (CorngameSFXs [0], 1.0f);
			break;
		case "squeek":
			PlayClip (CorngameSFXs [1], 1.0f);
			break;
		}

	}


}
