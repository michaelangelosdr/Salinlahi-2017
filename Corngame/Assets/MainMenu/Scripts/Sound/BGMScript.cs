using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : SoundScript {

	private static BGMScript instance;

	public static BGMScript Instance {

		get { 
		
			return instance;
		}
	}

	public AudioSource audioSource;

	public AudioClip mainMenuClip;
	public AudioClip CornGameClip;
	public AudioClip MangoBGM;
	public AudioClip BugAwayBGM;
	public AudioClip bgmClip;


	void Start() {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();

		GetOriginalVolume ();
	}

	void Update() {

		if (!enabled) {
		
			audioSource.volume = 0;
		}
	}

	public void PlayClip(AudioClip newClip, float volume = 0.75f) {

		if (!enabled)
			return;

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
		PlayClip (CornGameClip,0.5f);
	}

	public void PlayMangoBGM() {
	
		PlayClip (MangoBGM, 0.5f);
	}
	public void PlayBugAwayBGM()
	{
		PlayClip (BugAwayBGM, 0.5f);
	}
}
