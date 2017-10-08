using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn_Script : MonoBehaviour {


	private bool Is_Rotten;
	private bool Is_Clean;
	public bool IS_Tappable;
	public int life;

	[SerializeField] GameObject Child_Corn;
	[SerializeField] GameObject Sadface;
	[SerializeField] GameObject Child_Corn_Rotten;
	[SerializeField] GameObject Child_Corn_Rotten2;
	[SerializeField] GameObject Child_Corn_Rotten3;
	[SerializeField] Main_GameController GM_script;
	[SerializeField] SFX_Controler_script sfxscript;

	public void Summon_Corn(int cornlife)
	{
		Is_Rotten = false;
		Is_Clean = true;
		Sadface.SetActive(false);
		Clear_AllCorns ();
		life = cornlife;

	}


	public bool CheckCorn()
	{
		return Is_Rotten;
	}
		

	public void ChangeCorn()
	{

		if (life <= 0) {
			Is_Rotten = !Is_Rotten;
			Is_Clean = !Is_Clean;
			Child_Corn.SetActive (Is_Clean);
			Child_Corn_Rotten.SetActive (Is_Rotten);
		
		} else {
			Is_Rotten = true;
			ShowRottenCorn (life);
		}
	}





	//Temporary Click Debug
	void OnMouseDown()
	{
		if (IS_Tappable) {
			if (Is_Rotten) {
				if (life >= 2) {
					Child_Corn_Rotten2.GetComponent<Animation> ().Play ();
					life--;
					ShowRottenCorn (life);
				} else if (life == 1) {
					Child_Corn_Rotten.GetComponent<Animation> ().Play ();
					life--;
					ShowRottenCorn (life);
				} else if (life <= 0) {
					Clear_AllCorns ();
					Child_Corn.GetComponent<Animation> ().Play ();
					Is_Rotten = false;
				}
				GM_script.Add_Score ();
				if (GM_script.AlreadyAdded) {
					GM_script.AlreadyAdded = false;
				}
			} else {			
				StartCoroutine (DelayFace ());
				Child_Corn.GetComponent<Animation> ().Play ();
				GM_script.Life_Decreased ();
			}
			sfxscript.Play_SFX ("blop");
		}
	}




	public void ShowRottenCorn(int CornLife)
	{
		if (CornLife >= 2) {
			Child_Corn_Rotten3.SetActive (true);
			Child_Corn_Rotten2.SetActive (false);
			Child_Corn_Rotten.SetActive (false);
			Child_Corn.SetActive (false);
		} else if (CornLife == 1) {
			Child_Corn_Rotten3.SetActive (false);
			Child_Corn_Rotten2.SetActive (true);
			Child_Corn_Rotten.SetActive (false);
			Child_Corn.SetActive (false);
		} else if (CornLife == 0) {
			Child_Corn_Rotten3.SetActive (false);
			Child_Corn_Rotten2.SetActive (false);
			Child_Corn_Rotten.SetActive (true);
			Child_Corn.SetActive (false);
		} else {

			Debug.Log ("NULL HERE");
		}
	}
	public void Clear_AllCorns()
	{
		Child_Corn_Rotten3.SetActive (false);
		Child_Corn_Rotten2.SetActive (false);
		Child_Corn_Rotten.SetActive (false);
		Child_Corn.SetActive (true);
	
	}


	IEnumerator DelayFace()
	{
		Sadface.SetActive (true);
		yield return new WaitForSeconds (0.4f);
		Sadface.SetActive (false);
	}


}
