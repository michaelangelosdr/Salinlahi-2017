using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugAway_TowerSpawn : MonoBehaviour {

	[SerializeField] Image image;

	public List<Sprite> sprites;

	public List<GameObject> TowerPrefabs;

	GameObject TowerToSummon;

	void Update() {

		if (InsectGameControllerTAP.Instance.removing)
			image.color = Color.gray;
		else
			image.color = Color.white;
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
	public void SpawnTowerTo(Vector3 TowerSpot,string Tag,int TowerIndex,GridScriptTAP Grid)
	{
        //Spawns towers here
        //Towerclone's name should be received from a new made gameobject. will edit this in the future
        string Tower_name= "";

		GameObject TowerClone = Instantiate (TowerToSummon, TowerSpot + Vector3.forward * 3, Quaternion.identity) as GameObject;

        TowerClone.GetComponent<BugAway_Tower_BASEclass>().SetGrid(Grid);
		Grid.tower = TowerClone;

        switch (TowerIndex)
		{
			case 0: Tower_name = "Wasp shooter";break;
            case 1: Tower_name = "Punching Sack";break;
            case 2: Tower_name = "Baygon";break;

        }
        TowerClone.name = Tower_name;
		TowerClone.tag = Tag + "_tower";

		InsectGameControllerTAP.Instance.ReduceSeeds (TowerIndex);
	}


}
