using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Text_Reader_Script : MonoBehaviour {



	string CornGametxt = "Assets/Corn_Game/info.txt";

	//Assign your Info txt's location here

	string MangoGameTxt;
	string InsectGameTxt;

	[SerializeField] Text TextComponent;
	List<string> Trivias;



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

		Debug.Log ("Loading Trivia");
		Trivias = new List<string> ();
		StreamReader File = new StreamReader (CornGametxt);
			do{
				string data;
				data = File.ReadLine();
				string[] datas = data.Split('/');

			Trivias.Add(datas[0]);

			}while (!File.EndOfStream);
				
		Debug.Log ("Trivias entered: " + Trivias.Count);
		File.Close ();

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
