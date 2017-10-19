using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bugaway_Enemies_BaseClass : MonoBehaviour {

	public int Damage
	{
		get { return Damage;}
		set { Damage = value; }
	}

	public int Health
	{
		get { return Health; }
		set { Health = value; }
	}


	public float speed
	{
		get { return speed; }
		set { speed = value; }
	}

	public Vector2 V2pos
	{
		get { return V2pos; }
		set { V2pos = value; }
	}



	public virtual void Move()
	{

		float yMovement = V2pos.y;
		yMovement += speed;
		transform.position = new Vector2 (V2pos.x, yMovement);
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

}
