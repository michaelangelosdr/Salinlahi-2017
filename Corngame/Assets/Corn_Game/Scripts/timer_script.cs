using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_script : MonoBehaviour {

	private float Internal_Timer;
	public float Set_Time;
	private bool timer_bool;
	public float Time_Cap;

	//Change this to a bar or a animating clock
	[SerializeField] GameObject Timer_Object;
	[SerializeField] Main_GameController M_gamecontroller;


	// Use this for initialization
	void Start () {
		Time_Cap = 0;
		Internal_Timer = Set_Time;
	}
	
	// Update is called once per frame
	void Update () {


		if (timer_bool) {			
			Internal_Timer -= Time.deltaTime;
			Timer_Object.GetComponent<Text> ().text =Mathf.Round (Internal_Timer).ToString ();
			if (Internal_Timer <= 0) {
				
				//Minus one health

				//Timer_Reset ();
				M_gamecontroller.Is_GameOver();
				Timer_Stop ();
				Debug.Log ("Timer Done, Game Over");
				//GameOver


			}
		}
	}
		


	public void Timer_Stop()
	{
		timer_bool = false;
	}

	public void Timer_Reset()
	{
		timer_bool = true;
		Internal_Timer = Set_Time - Time_Cap;
	}
	public void Timer_Resume()
	{
		timer_bool = true;
	}

	public void DecreaseTime()
	{
		Time_Cap += 0.5f;
	}
}
