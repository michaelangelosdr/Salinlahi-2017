using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByTime : MonoBehaviour {

	public float time;

	void OnEnable () {

		Invoke ("Disable", time);
	}

	void Disable() {

		gameObject.SetActive (false);
	}
}
