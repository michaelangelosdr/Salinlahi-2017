using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public void Unlock() {


	}

	public void Replay() {

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void GoBackHome() {
	
		SceneManager.LoadScene ("Main_Menu");
	}
}
