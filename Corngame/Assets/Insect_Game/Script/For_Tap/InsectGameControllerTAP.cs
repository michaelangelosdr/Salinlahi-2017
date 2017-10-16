using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectGameControllerTAP : MonoBehaviour {

	public bool Selected;
	public List<GridScriptTAP> Grids;
	public BugAway_TowerSpawn TowerHolder;



	// Use this for initialization
	void Start () {

		Selected = false;
		
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
			grid.ShowThisGrid();
		}

	}
		

	public void TowerDeselected()
	{
		Selected = false;
		foreach (GridScriptTAP grid in Grids) {
			grid.HideThisGrid ();
		}
		TowerHolder.Reset ();

	}

	public void GiveTowerDataToHolder(int towerType)
	{
		//Tower data will be sent by index 
		TowerHolder.HoldTower (towerType);
	}

	public void GivePositionToSpawner(Vector3 spot)
	{
		TowerHolder.SpawnTowerTo (spot);
		Selected = false;
	}	
}
