using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : SoundScript {
	
	private static SFXScript instance;

	public static SFXScript Instance {

		get { 

			return instance;
		}
	}

	AudioSource audioSource;
	public List<AudioClip> CorngameSFXs;
	public AudioClip mangoSpray;

	void Start() {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		GetOriginalVolume ();

		audioSource = GetComponent<AudioSource> ();
	}

	void Update() {

		if (!enabled) {

			audioSource.volume = 0;
		}
	}

	public void PlayClip(AudioClip newClip,float volume = 1.0f) {

		if (!enabled)
			return;
		
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

	public void PlayMangoSpray() {

		PlayClip (mangoSpray, 0.0625f);
	}
}
