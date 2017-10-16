using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugAway_TowerSpawn : MonoBehaviour {

	[SerializeField] Image image;


	public List<Sprite> sprites;


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void CreateTower(int Index)
	{
		switch (Index) {
		case 0:
			//Basic tower data load
			Debug.Log ("Holding Basic Tower");
			image.sprite = sprites [Index];
			break;
		}

	}


}
