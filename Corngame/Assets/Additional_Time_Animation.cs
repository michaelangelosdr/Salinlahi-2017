using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Additional_Time_Animation : MonoBehaviour {

	[SerializeField] Transform Original;
	float YAxis;
	float ctr;

	void Awake()
	{
		
		transform.position = Original.position;
		YAxis = transform.position.y;
		ctr = 3;
	}


	void FixedUpdate()
	{

		ctr -= Time.deltaTime;

		if (ctr > 0) {
			YAxis++;
		} else {
			Awake ();
			gameObject.SetActive (false);
		}
	
		transform.position = new Vector2 (transform.position.x, YAxis);
	}

}
