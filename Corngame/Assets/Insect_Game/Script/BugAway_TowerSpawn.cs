using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugAway_TowerSpawn : MonoBehaviour {

	[SerializeField] Image image;


	public List<Sprite> sprites;

	public List<GameObject> TowerPrefabs;

	GameObject TowerToSummon;


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void HoldTower(int Index)
	{
			image.sprite = sprites [Index];
			TowerToSummon = TowerPrefabs [Index];
	}

	public void Reset()
	{
		image.sprite = null;
		TowerToSummon = null;

	}

	public void SpawnTowerTo(Vector3 TowerSpot)
	{

		//Spawns towers here
		//Towerclone's name should be received from a new made gameobject. will edit this in the future
		Debug.Log ("TowerPlaced");
		GameObject TowerClone = Instantiate (TowerToSummon, TowerSpot, Quaternion.identity) as GameObject;
		TowerClone.name = "Summoned tower";



	}


}
