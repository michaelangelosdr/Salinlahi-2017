using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trivia_Script : MonoBehaviour {

    
    private string GameName;
    private int MaxGameScore;
    public int GameScore;
    [SerializeField] GameObject GameOverCanvass;

 

    // Use this for initialization
    void OnEnable() {
        StartCoroutine(WaitLungs());      
    }
    public void GiveNewScore(int score)
    {
        GameScore = score;
        if (GameScore > MaxGameScore)
        {
            PlayerDataLoaderScript.Instance.SaveGameData(SceneManager.GetActiveScene().name.ToString(), GameScore);
        }
    }

    public void Close()
    {
        GameOverCanvass.SetActive(true);
        gameObject.SetActive(false);

    }


    IEnumerator WaitLungs()
    {
        yield return new WaitForEndOfFrame();
        GameName = SceneManager.GetActiveScene().name;
        MaxGameScore = PlayerDataLoaderScript.Instance.GetData(GameName);

        // MaxGameScore = PlayerDataLoaderScript.Instance.GetData(GameName);

       

        //Hide already unlocked buttons
        foreach (Transform T in transform)
        {

            try { T.gameObject.GetComponent<Trivia_Points_unlocker>().Unlocker(MaxGameScore); }
             catch { Debug.Log("LOL"); };

        }
    }
}
