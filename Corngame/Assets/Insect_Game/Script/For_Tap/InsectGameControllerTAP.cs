using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsectGameControllerTAP : MonoBehaviour {

	private static InsectGameControllerTAP instance;

	public bool Selected;
	public bool removing;
	public List<GridScriptTAP> Grids;
	public BugAway_TowerSpawn TowerHolder;

	public Insect_Spawner spawner;

	public List<Image> buttons;

    private int towerInd;
	public int enemiesToSpawn;
	public int killCounter;

	public int currentSeeds;
	public List<int> seedAmounts;

	public float plantingPhaseTimer;

	bool plantingDone;

	public EndpointScript endpoint;

	public static InsectGameControllerTAP Instance {

		get { 
		
			return instance;
		}
	}

	void Start () {

		instance = this;

		Selected = false;

		StartCoroutine (StartGame ());
	}

	void ResetValues() {

		currentSeeds = 100;
		plantingDone = false;
		enemiesToSpawn = killCounter = 5;
	}

	void ButtonTint(int index) {
	
		ResetButtonTints ();
		buttons [index].color = Color.grey;
	}

	void ResetButtonTints() {

		foreach (Image i in buttons)
			i.color = Color.white;
	}

	public void TowerSelected(int index)
	{
		if (currentSeeds < seedAmounts [index])
			return;

		if (plantingDone)
			return;

		if (Selected) {
	
			TowerDeselected ();
			return;
		}

		Debug.Log ("Tower has been chosen");	
		Selected = true;
		ShowAvailableGrids ();
		GiveTowerDataToHolder (index);

        towerInd = index;

		ButtonTint (index);
	}

	public void ReduceSeeds(int index) {
	
		currentSeeds -= seedAmounts [index];
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

        towerInd = 0;
	}

	public void GiveTowerDataToHolder(int towerType)
	{
		//Tower data will be sent by index 
		TowerHolder.HoldTower (towerType);
	} 

	public void GivePositionToSpawner(Vector3 spot,string Tagg,GridScriptTAP Grid)
	{
		Debug.Log (Tagg);
		TowerHolder.SpawnTowerTo (spot,Tagg,towerInd,Grid);
		Selected = false;
	}	

	IEnumerator StartGame() {

		while (true) {
		
			yield return null;

			ResetValues ();

			Debug.Log ("Plant NOW!");

			yield return new WaitForSeconds (plantingPhaseTimer);

			Debug.Log ("STOP PLANTING");

			plantingDone = true;

			spawner.StartRound (5);

			yield return new WaitForEndOfFrame ();

			yield return new WaitUntil (() => !spawner.spawningBugs);

			Debug.Log ("DONE SPAWNING");

			bool gameOver = false;

			while (true) {

				if (endpoint.gameOver) {

					gameOver = true;
					break;
				}

				if (killCounter <= 0)
					break;

				yield return null;
			}

			if (gameOver) {
				
				break;
			} else {

				Debug.Log ("Well done!");
			}
		}

		Debug.Log ("GAME OVER!");
	}

	public void RemoveThing() {

		if (removing)
			Removed ();

		removing = true;
	}

	public void Removed() {
	
		removing = false;
	}
}
