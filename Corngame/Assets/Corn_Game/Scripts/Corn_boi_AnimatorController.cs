using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn_boi_AnimatorController : MonoBehaviour {

	[SerializeField] Animator CornBoi_Animator;
	[SerializeField] GameObject Bomb;
	public	GameObject Tapped_Corn;
	//bool Throw;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void Play_Throw_Animation()
	{


		//Throw = true;
		CornBoi_Animator.SetBool ("Throw", true);

	}

	public void End_Throw_Animation()
	{
	//	Throw = false;
		CornBoi_Animator.SetBool ("Throw", false);
	}


	public void Give_Corn_Tapped(GameObject Corn_Tapped)
	{
		Tapped_Corn = Corn_Tapped;

	}
}
