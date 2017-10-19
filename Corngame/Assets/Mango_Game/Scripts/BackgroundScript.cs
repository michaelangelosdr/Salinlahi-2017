using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	List<Animator> animators;

	void Start () {

		animators = new List<Animator> ();

		foreach (Transform t in transform) {

			Animator ac = t.GetComponent<Animator> ();

			Debug.Log (ac);

			if (ac != null)
				animators.Add (ac);
		}
	}

	public void Animate() {

		foreach (Animator ac in animators)
			ac.SetTrigger ("spray");
	}
}
