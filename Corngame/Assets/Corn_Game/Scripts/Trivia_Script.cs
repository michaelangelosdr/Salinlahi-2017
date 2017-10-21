using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trivia_Script : MonoBehaviour {

    [SerializeField] List<int> CornGame_UnlockPoint;
    [SerializeField] List<int> MangoGame_UnlockPoint;
    [SerializeField] List<int> InsectGame_UnlockPoint;

    [SerializeField] List<GameObject> Buttons;

    private int MaxGameScore;
    public int GameScore;
    // Use this for initialization
    void Start () {

     MaxGameScore = PlayerDataLoaderScript.Instance.GetData(SceneManager.GetActiveScene().name.ToString());            
        

	}

    public void UnlockButton(int ButtonIndex)
    {
        if (GameScore >  )
        {
            Debug.Log(gameObject.name);
            gameObject.SetActive(false);
        }
    }

    public void GiveNewScore(int score)
    {
        GameScore = score;
        if (GameScore > MaxGameScore)
        {
            PlayerDataLoaderScript.Instance.SaveGameData(SceneManager.GetActiveScene().name.ToString(), GameScore);
        }
    }
}
