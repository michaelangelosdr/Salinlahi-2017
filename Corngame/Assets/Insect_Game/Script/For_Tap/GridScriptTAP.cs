using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScriptTAP : MonoBehaviour {


	private SpriteRenderer sr;
	public bool Occupied;
	public InsectGameControllerTAP GMScript;

	[SerializeField] Sprite GridGood;
	[SerializeField] Sprite GridBad;



	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ShowThisGrid()
	{
		if (Occupied) {
//			sr.sprite = GridBad;
		} else {
			sr.sprite = GridGood;
		}
	}

	public void HideThisGrid()
	{
		sr.sprite = null;
	}


	void OnMouseDown()
	{
		//If Currency is good
		//If Space is not occupied
		if(!Occupied)
		{
			Debug.Log (" Clicked this grid, Spawning tower ");
			GMScript.GivePositionToSpawner (gameObject.transform.position);
			Occupied = true;
			GMScript.TowerDeselected ();
		}
	}

}
