using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsectGameControllerTAP : MonoBehaviour {

	public bool Selected;
	public List<GridScriptTAP> Grids;
	public BugAway_TowerSpawn TowerHolder;

	public List<Image> buttons; 

	// Use this for initialization
	void Start () {

		Selected = false;
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ButtonTint(int index) {
	
		buttons [index].color = Color.grey;
	}

	void ResetButtonTints() {

		foreach (Image i in buttons)
			i.color = Color.white;
	}

	public void TowerSelected(int index)
	{
		Debug.Log ("Tower has been chosen");	
		Selected = true;
		ShowAvailableGrids ();
		GiveTowerDataToHolder (index);

		ButtonTint (index);
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
		Debug.Log ("Deselected");

		ResetButtonTints ();

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

	public void GivePositionToSpawner(Vector3 spot,string Tagg)
	{
		Debug.Log (Tagg);
		TowerHolder.SpawnTowerTo (spot,Tagg);
		Selected = false;
	}	
}
