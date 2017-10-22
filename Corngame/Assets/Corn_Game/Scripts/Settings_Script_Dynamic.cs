using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Script_Dynamic : MonoBehaviour {



	[SerializeField] GameObject SettingsPrefab;
	[SerializeField] GameObject Music_Button_on;
	[SerializeField] GameObject Music_Button_off;
	[SerializeField] GameObject SFX_Button_on;
	[SerializeField] GameObject SFX_Button_off;
	[SerializeField] timer_script T_Script;
	[SerializeField] Corn_Controller Corn_Cont;
	public bool Is_Closed;



	



		
	public void Close_Settings()
	{
		SettingsPrefab.SetActive (false);
		T_Script.Timer_Resume ();
		Is_Closed = true;
		Corn_Cont.Corns_Tappable (Is_Closed);
	}

	public void Toggle_Music_Off()
	{
		Music_Button_on.SetActive (false);
		Music_Button_off.SetActive (true);
		//Set MusicControllerHere
	}

	public void Toggle_Music_On()
	{
		Music_Button_on.SetActive (true);
		Music_Button_off.SetActive (false);
		//Set Music controller Here
	}
	public void Toggle_SFX_Off()
	{
		SFX_Button_on.SetActive (false);
		SFX_Button_off.SetActive (true);
		//Set MusicControllerHere
	}

	public void Toggle_SFX_On()
	{
		SFX_Button_on.SetActive (true);
		SFX_Button_off.SetActive (false);
		//Set Music controller Here
	}


}
