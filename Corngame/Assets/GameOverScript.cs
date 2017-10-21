using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {


    private string SceneName;

    private void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }

    public void Unlock() {
        if(SceneName == "Corn_prototype")
        {
            GameObject.Find("Main Camera").GetComponent<Main_GameController>().Open_Trivia();
        }


	}

	public void Replay() {

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void GoBackHome() {
	
		SceneManager.LoadScene ("Main_Menu");
	}

    



}
