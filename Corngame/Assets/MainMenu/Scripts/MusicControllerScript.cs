using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControllerScript : MonoBehaviour {

	public SoundScript soundScript;

	public Sprite imageOn;
	public Sprite imageOff;

	public Image buttonImage;

	float originalVolume;

	bool enabled;

	void Start () {

		enabled = true;
	}

	public void ButtonClick() {
	
		enabled = !enabled;
		soundScript.enabled = enabled;

		if (enabled) {
			
			soundScript.SetToOriginalVolume ();
			buttonImage.sprite = imageOn;

		} else {
			
			buttonImage.sprite = imageOff;
		}
	}
}
