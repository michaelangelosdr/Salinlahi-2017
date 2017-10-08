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

	void Start() {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClip(AudioClip newClip) {
		
		audioSource.PlayOneShot (newClip);
	}
}
