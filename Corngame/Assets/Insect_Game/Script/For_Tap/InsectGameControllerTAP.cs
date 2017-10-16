using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectGameControllerTAP : MonoBehaviour {

	public bool Selected;
	public List<GridScriptTAP> Grids;
	public BugAway_TowerSpawn TowerHolder;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}




	public void TowerSelected(int index)
	{
		Debug.Log ("Tower has been chosen");	
		Selected = true;
		ShowAvailableGrids ();
		GiveTowerDataToHolder (index);
	}
	public void ShowAvailableGrids()
	{
		foreach (GridScriptTAP grid in Grids) {

			//Method for showing Grids
		}

	}

	public void GiveTowerDataToHolder(int towerType)
	{
		//Tower data will be sent by index 
		TowerHolder.CreateTower (towerType);

	}
	

}
