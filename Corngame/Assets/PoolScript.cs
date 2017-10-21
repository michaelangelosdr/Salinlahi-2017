using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour {

	public GameObject GetNext() {

		foreach (Transform t in transform) {
		
			if (!t.gameObject.activeInHierarchy)
				return t.gameObject;
		}

		return null;
	}
}
