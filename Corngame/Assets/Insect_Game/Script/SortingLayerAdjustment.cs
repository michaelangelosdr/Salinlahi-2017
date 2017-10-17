using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerAdjustment : MonoBehaviour {

	SpriteRenderer sr;

	void Start() {

		sr = GetComponentInChildren<SpriteRenderer> ();
	}

	void Update () {

		sr.sortingOrder = (int)(transform.position.x * -10);
	}
}
