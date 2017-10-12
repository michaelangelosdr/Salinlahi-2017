using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControllerScript : MonoBehaviour {

	public AudioSource audioSource;

	public Sprite imageOn;
	public Sprite imageOff;

	public Image buttonImage;

	float originalVolume;

	bool enabled;

	void Start () {

		enabled = true;
		originalVolume = audioSource.volume;


	}

	public void ButtonClick() {
	
		enabled = !enabled;

		if (enabled) {
			
			audioSource.volume = originalVolume;
			buttonImage.sprite = imageOn;

		} else {
			
			audioSource.volume = 0;
			buttonImage.sprite = imageOff;
		}
	}
}
