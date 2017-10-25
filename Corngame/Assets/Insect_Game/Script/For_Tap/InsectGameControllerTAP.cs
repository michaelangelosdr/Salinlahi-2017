using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsectGameControllerTAP : MonoBehaviour {

	private static InsectGameControllerTAP instance;

	public BossBugScript bossBug;

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
	public int seedsToGive;
	public List<int> seedAmounts;

	public int roundNumber;

	public float plantingPhaseTimer;

	public bool plantingDone;
	bool gaming;

	public EndpointScript endpoint;

	public Text seedText;
	public Text score;
	public Text roundUI;
	public Text phaseUI;

	public GameObject gameOverOverlay;
	public GameObject tutorialOverlay;

	public float HealthIncrement;
	public float SpeedIncrement;

	public static InsectGameControllerTAP Instance {

		get { 
		
			return instance;
		}
	}

	void Start () {
		
		Time.timeScale = 1;

		seedsToGive = 30;

		instance = this;

		Selected = false;

		HealthIncrement = 0;
		SpeedIncrement = 0;

		SoundUIScript.Instance.Landscape ();

		StartCoroutine (StartGame ());

		SetRoundText ();

		gameOverOverlay.SetActive (false);
		tutorialOverlay.SetActive (true);

		SetPhaseText ("Planting");
	}

	void Update() {
		
		seedText.text = currentSeeds + "\nSEEDS";
	}

	void ResetValues() {

		SetRoundText ();

		enemiesToSpawn = Mathf.Clamp (enemiesToSpawn, 0, 20);

		currentSeeds = seedsToGive;

		if(seedsToGive > 60)
			seedsToGive -= 10;
		
		plantingDone = false;
		killCounter = enemiesToSpawn;

	}

	void SetRoundText() {

		roundUI.text = "Wave " + roundNumber.ToString ();
	}

	void SetPhaseText(string s) {

		phaseUI.text = "Phase: " + s;
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

//		Debug.Log ("Tower has been chosen");	
		Selected = true;
		removing = false;
		ShowAvailableGrids ();
		GiveTowerDataToHolder (index);
		SFXScript.Instance.PlayOverallSFX ("tap");
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
//		Debug.Log ("Deselected");

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
//		Debug.Log (Tagg);
		TowerHolder.SpawnTowerTo (spot,Tagg,towerInd,Grid);
		Selected = false;
	}	

	IEnumerator StartGame() {
		
		roundNumber = 1;

		gaming = true;

		while (true) {
		
			yield return null;

			ResetValues ();

			Debug.Log ("Plant NOW!");

			for (int i = 0; i < plantingPhaseTimer; i++) {
			
				SetPhaseText ("Planting (" + (plantingPhaseTimer - i).ToString () + ")");

				if (currentSeeds <= 0)
					break;

				yield return new WaitForSeconds (1);
			}

			Debug.Log ("STOP PLANTING");

			SetPhaseText ("Defense");
			TowerDeselected ();
			removing = false;
			plantingDone = true;

			bool gameOver = false;

			bool bossRound = roundNumber % 5 == 0;

			if (bossRound) {

				BGMScript.Instance.PlayBugAwayBossFightBGM ();
				bossBug.gameObject.SetActive (true);
			} else {

				spawner.spawningBugs = true;

				spawner.StartRound (enemiesToSpawn++);

				yield return new WaitUntil (() => !spawner.spawningBugs);



//				Debug.Log ("DONE SPAWNING");
			}

			while (true) {

//				Debug.Log ("Waiting " + Time.time);

				if (endpoint.gameOver) {

					gameOver = true;
					break;
				}

				if (killCounter <= 0)
					break;

				if (bossBug.killed && bossRound) {
				
					if (bossBug.Health < 25) {
						bossBug.Health += 5;
					}
						HealthIncrement += 0.5f;
						SpeedIncrement += 0.25f;
					Debug.Log ("Increase now: " + HealthIncrement);
					
					break;
				}

				yield return null;
			}

			if (gameOver) {
				
				break;
			} else {

//				Debug.Log ("Well done!");

				roundNumber++;
			}
		}

		gaming = false;

		GameOver ();
	}

	public void FastForward() {

//		Debug.Log ("Fast Forward");

		if (gaming && !removing) {
			Time.timeScale = Time.timeScale != 1 ? 1 : 3;
			BGMScript.Instance.IncreasePitch (Time.timeScale);
		}

	}

	void GameOver() {

		Debug.Log ("GAME OVER!");

		Time.timeScale = 0;
		score.text = (roundNumber - 1).ToString ();
		gameOverOverlay.SetActive (true);
	}

	public void RemoveThing() {

		if (removing) {

			Removed ();
			return;
		}

		removing = true;
		TowerDeselected ();
	}

	public void Removed() {
	
		removing = false;
	}
}
