using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {


    private string SceneName;
    [SerializeField] GameObject triviaBox;

	void OnEnable() {

		Time.timeScale = 1;
		BGMScript.Instance.SetPitch (1);
	}

    private void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }

    public void Unlock() {
        int TempScoreHolder = int.Parse( GameObject.Find(SceneName + "Score").GetComponent<Text>().text);
        Debug.Log(TempScoreHolder);
       
        triviaBox.SetActive(true);
        triviaBox.GetComponent<Trivia_Script>().GiveNewScore(TempScoreHolder);
        gameObject.SetActive(false);
	}

	public void Replay() {

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void GoBackHome() {
	
		SceneManager.LoadScene ("Main_Menu");
	}

    



}
