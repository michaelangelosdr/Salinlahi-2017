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
	public List<AudioClip> InsectGameSFXs;
	public List<AudioClip> OverallSFX;
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
            case "Shwing":
                PlayClip(CorngameSFXs[2], 1.0f);
                break;
		}

	}

	public void PlayOverallSFX(string nameOfSFX)
	{
		switch (nameOfSFX) {
		case "tap":
			PlayClip (OverallSFX [0], 1.0f);
			break;
		}


	}

	public void BugAwayPlaySFX(string nameOfSFX)
	{
		switch (nameOfSFX) {
		case "Bug_Summon":
			PlayClip (InsectGameSFXs [0], 1.0f);
			break;
		case "Bug_Death":
			PlayClip(InsectGameSFXs[1], 0.5f);
			break;
		case "Bug_Hit":
			PlayClip (InsectGameSFXs [2], 0.8f);	
			break;
		case "tower1_shoot":
			PlayClip (InsectGameSFXs [3], 0.8f);
			break;
		case "tower2_shoot": //TODO: ADD TOWER SHOOT OR DEFENSE SFX
			PlayClip (InsectGameSFXs [1], 0.8f);
			break;
		case "tower3_shoot": //TODO: ADD EXPLOSION
			PlayClip (InsectGameSFXs [5], 0.8f);
			break;
	
		case "Boss_BugSpawn":
			PlayClip (InsectGameSFXs [6], 1f);
			break;
		}

	}


	public void PlayMangoSpray() {

		PlayClip (mangoSpray, 0.0625f);
	}
}
