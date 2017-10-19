using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_animation : MonoBehaviour {


	float X;
	float Y;
	[SerializeField] Transform Startpoint;

	// Use this for initialization
	void Start (){
		
		X = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (X < -7.0f) {
			X = Startpoint.position.x;
			Y = Startpoint.position.y;

		} else {
			
			X -= 0.01f;
			transform.position = new Vector2 (X, transform.position.y);
		}

	

	}
}
