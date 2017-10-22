using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Manager_Script : MonoBehaviour {


	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	public void Call_Scene(int SceneIndex)
	{
			SceneManager.LoadScene (SceneIndex);
	}

}
