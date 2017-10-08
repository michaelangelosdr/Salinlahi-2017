using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGRamonScript : MonoBehaviour {

	[SerializeField] Animator ac;

	[SerializeField] GameObject water;

	void Spray() {

		ac.SetTrigger ("spray");
	}

	void ShowWater() {

		water.SetActive (true);
	}

	void HideWater() {
	
		water.SetActive(false);
	}
}
