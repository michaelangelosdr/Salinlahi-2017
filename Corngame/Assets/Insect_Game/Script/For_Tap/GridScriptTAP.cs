﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScriptTAP : MonoBehaviour {
	
	private SpriteRenderer sr;
	public bool Occupied;
	public InsectGameControllerTAP GMScript;

	[SerializeField] Sprite GridGood;
	[SerializeField] Sprite GridBad;

	public GameObject tower;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
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
		
    public void Restore_Grid()
    {
		Occupied = false;
		Destroy (tower);

		InsectGameControllerTAP.Instance.Removed ();
    }

	void OnMouseDown()
	{

		if (InsectGameControllerTAP.Instance.Selected || InsectGameControllerTAP.Instance.removing) {

			//If Currency is good
			//If Space is not occupied
			if(!Occupied)
			{
				Debug.Log (" Clicked this grid, Spawning tower ");
				GMScript.GivePositionToSpawner (gameObject.transform.position, this.gameObject.tag.ToString(),this);
				Occupied = true;
				GMScript.TowerDeselected ();
			}

			if (Occupied && InsectGameControllerTAP.Instance.removing) {

				Restore_Grid ();
			}
		}
	}

}
