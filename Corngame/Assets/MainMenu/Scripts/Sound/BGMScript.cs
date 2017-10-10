using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour {

	private static BGMScript instance;

	public static BGMScript Instance {

		get { 
		
			return instance;
		}
	}

	AudioSource audioSource;

	public AudioClip mainMenuClip;
	public AudioClip CornGameClip;
	public AudioClip bgmClip;


	void Start() {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClip(AudioClip newClip, float volume = 0.75f) {

		audioSource.volume = volume;
		audioSource.clip = newClip;
		audioSource.Play ();
	}

	public void PlayMainMenu() {
		
		PlayClip (mainMenuClip);
	} 

	public void PlayBGM() {

		PlayClip (bgmClip);
	} 

	public void PlayCornGameBGM()
	{
		PlayClip (CornGameClip,0.1f);
	}
}
