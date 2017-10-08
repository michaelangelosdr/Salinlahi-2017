using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_Script : MonoBehaviour {


	int Direction;
	int Bug_Type;
	public float Bug_x;
	public float Bug_y;
	bool Go_Move;
	public float Bug_Movement_Speed;
	public float Living_time;
	bool Is_Wasp;

	[SerializeField] GameObject Spider_Bug;
	[SerializeField] GameObject Wasp_bug;
	[SerializeField] Life_Script Life;
	[SerializeField] Insect_Score_Script I_score_Script;

	// Use this for initialization
	void Start () {
		Bug_Type = 0;
		Direction = 0;
		Living_time = 5;
		Bug_Movement_Speed = 0.025f;
		Stop_Movement ();
	}

	// Update is called once per frame
	void Update () {
	
		if (Go_Move) {
			
			if (Direction == 1) {
				Bug_x += Bug_Movement_Speed;
			}
			if (Direction == 2) {
				Bug_x -= Bug_Movement_Speed;
			}
			if (Direction == 3) {
				Bug_y -= Bug_Movement_Speed;
			}
		
			Living_time -= Time.deltaTime;

			if (Living_time <= 0) {
				Stop_Movement ();
			}

			transform.position = new Vector2 (Bug_x, Bug_y);
		} else {
			Living_time = 5;
			gameObject.SetActive (false);
		}





	}




	public  void SummonBug(GameObject Point)
	{		

		if (Point.gameObject.tag == "Left_spawn") {
			if (Is_Wasp) {
				Wasp_bug.GetComponent<SpriteRenderer> ().flipX = true;
			} else {
				Spider_Bug.GetComponent<SpriteRenderer> ().flipX = true;
			}
			Direction = 1;
			//Debug.Log (gameObject.name + "is going Right");
		}

		else if (Point.gameObject.tag == "Right_Spawn") {
			//Debug.Log (gameObject.name + "is going Left");

			if (Is_Wasp) {
				Wasp_bug.GetComponent<SpriteRenderer> ().flipX = false;
			} else {
				Spider_Bug.GetComponent<SpriteRenderer> ().flipX = false;
			}
			Direction = 2;

		}
		else if (Point.gameObject.tag == "Up_Spawn") {
			//Debug.Log (gameObject.name + "is going Down");
			Direction = 3;
		}

		transform.position = Point.transform.position;
		Bug_x = Point.transform.position.x;
		Bug_y = Point.transform.position.y;

		Resume_Movement ();
	}

	public void Randomize_Bug_Kind ()
	{
		//0 would be wasp 1 would be spyder
		Bug_Type = Random.Range (0, 2);
		if (Bug_Type == 0) {
			Spider_Bug.SetActive (false);
			Wasp_bug.SetActive(true);
			Is_Wasp = true;
		} else if (Bug_Type == 1) {
			Is_Wasp = false;
			Spider_Bug.SetActive (true);
			Wasp_bug.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.name == "Main_Player") {
			if (Is_Wasp) {
				I_score_Script.AddScore ();
			} else {
			
				if (Life.GetLives () != 0) {
					Life.DecreaseLife ();
				}
			}

			Stop_Movement ();
		}
	}


	public void Stop_Movement()
	{
		Go_Move = false;
	}
	public void Resume_Movement()
	{
		Go_Move = true;
	}



}
