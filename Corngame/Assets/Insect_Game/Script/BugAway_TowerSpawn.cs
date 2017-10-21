using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugAway_TowerSpawn : MonoBehaviour {

	[SerializeField] Image image;


	public List<Sprite> sprites;

	public List<GameObject> TowerPrefabs;

	GameObject TowerToSummon;



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
	public void SpawnTowerTo(Vector3 TowerSpot,string Tag,int TowerIndex)
	{
        //Spawns towers here
        //Towerclone's name should be received from a new made gameobject. will edit this in the future
        string Tower_name= "";
		GameObject TowerClone = Instantiate (TowerToSummon, TowerSpot, Quaternion.identity) as GameObject;
        switch (TowerIndex)
        {
            case 0: Tower_name = "Punching Sack";break;
            case 1: Tower_name = "Wasp shooter";break;
            case 2: Tower_name = "Baygon";break;

        }
        TowerClone.name = Tower_name;
		TowerClone.tag = Tag + "_tower";


	}


}
