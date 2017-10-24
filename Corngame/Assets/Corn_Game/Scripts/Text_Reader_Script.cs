using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Text_Reader_Script : MonoBehaviour {

	[SerializeField] Text TextComponent;
	List<string> Trivias;
	//[SerializeField] TextAsset Game_Trivias;


	// Use this for initialization
	void Start () {

		LoadTrivia ();
		/*
		for (int x = Trivias.Count-1; x >= 0; x--) {
			Debug.Log (Trivias [x] + "Trivia count: " + x);
		}*/

	}


	//How it works
	//Copy your trivia onto a text file then add a " / " on the end
	//The script will recognize the / and will turn everything into a string
	// please note that Spaces are still considered.
	void LoadTrivia()
	{
		//Debug.Log (Resources.Load (SceneManager.GetActiveScene ().name + "_info"));
		Trivias = new List<string> ();


			string data;
			data = Resources.Load (SceneManager.GetActiveScene ().name + "_info").ToString();
			string[] datas = data.Split('/');
		//Debug.Log (datas.Length);

		for (int x = 0; x <=datas.Length-2; x++) {
			Trivias.Add (datas [x]);
		}


				
		
		//File.Close ();

	}

	//This will randomize the trivias entered
	// This will also set the text of the text component
	//Call this to get yo trivia
	public void SetTrivia()
	{

		LoadTrivia ();
		TextComponent.text = Trivias [Random.Range(0,Trivias.Count)];
		//Debug.Log("Giving text to text component");
	}		
}
