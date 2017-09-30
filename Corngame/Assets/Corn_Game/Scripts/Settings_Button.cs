using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Button : MonoBehaviour {

	[SerializeField] GameObject Button_up;
	[SerializeField] GameObject Button_Down;

	void OnMouseDown()
	{
		Button_up.SetActive (false);
		Button_Down.SetActive(true);
	}
	void OnMouseUp()
	{
		Button_up.SetActive (true);
		Button_Down.SetActive(false);
	}
}
