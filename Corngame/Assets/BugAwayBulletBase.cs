﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAwayBulletBase : MonoBehaviour {

	public float speed;
	
	void Update () {

		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}
}