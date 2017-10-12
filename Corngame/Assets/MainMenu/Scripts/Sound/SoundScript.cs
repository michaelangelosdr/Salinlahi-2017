using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

	public bool enabled = true;

	public float originalVolume;

	public void GetOriginalVolume() {

		originalVolume = GetComponent<AudioSource> ().volume;
	}

	public void SetToOriginalVolume() {
		
		GetComponent<AudioSource> ().volume = originalVolume;
	}
}
