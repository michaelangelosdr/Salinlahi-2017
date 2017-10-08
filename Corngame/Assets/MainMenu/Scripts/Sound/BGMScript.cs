﻿using System.Collections;
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
	public AudioClip bgmClip;

	void Start() {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClip(AudioClip newClip) {

		audioSource.clip = newClip;
		audioSource.Play ();
	}

	public void PlayMainMenu() {
		
		PlayClip (mainMenuClip);
	} 

	public void PlayBGM() {

		PlayClip (bgmClip);
	} 
}