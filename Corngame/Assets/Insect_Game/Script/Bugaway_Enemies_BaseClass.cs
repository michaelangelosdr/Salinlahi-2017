using System.Collections;
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
		yMovement += speed/100;
		transform.position = new Vector2 (Position.x, yMovement);
	}

	public virtual void Getdamaged()
	{
		Health -= 1;
	}

	public void KillBug(GameObject thisbug)
	{
		//DestroyMe
		Destroy (thisbug.gameObject);
	}

	public virtual void Eat()
	{
		//Will this get eaten lolol
	}

	public virtual void SetStartPosition(Vector2 startPoint)
	{
		StartPoint = startPoint;

	
	}


}
