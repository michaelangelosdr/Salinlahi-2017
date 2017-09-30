using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Controler_script : MonoBehaviour {

	public List<AudioClip> L_Audioclips;
	static AudioSource a_source;

	// Use this for initialization
	void Start () {
		a_source = GetComponent<AudioSource> ();

	}



	public void Play_SFX(string NameOfAudio)
	{
		switch (NameOfAudio) {
		case "blop":
			a_source.PlayOneShot (L_Audioclips [0]);
			break;

		}

	}
}
