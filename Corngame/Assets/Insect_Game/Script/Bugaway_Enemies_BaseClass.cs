﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bugaway_Enemies_BaseClass : MonoBehaviour {

	public int Damage;
	public int Health;
	public float speed;
	public Vector2 StartPoint;

	public virtual void Move(Vector2 Position)
	{
		float yMovement = Position.y;
		yMovement += speed/50;
		transform.position = new Vector2 (Position.x, yMovement);
	}

	public virtual void Getdamaged()
	{
		if (Health > 1) {
			Health -= 1;
		} else {
			KillBug (this.gameObject);
		}

	}

	public virtual void KillBug(GameObject thisbug)
	{
		//DestroyMe
		if(InsectGameControllerTAP.Instance.plantingDone)
			InsectGameControllerTAP.Instance.killCounter--;

		thisbug.gameObject.SetActive (false);
	}

	public virtual void Eat_Tower()
	{
		//Will this get eaten lolol
        //lol i was so wasted coding this changed the name from EAT to EAT_TOWER()
	}

	public virtual void SetStartPosition(Vector2 startPoint)
	{
		StartPoint = startPoint;

	
	}


}
