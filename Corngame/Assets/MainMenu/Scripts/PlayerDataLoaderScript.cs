using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLoaderScript : MonoBehaviour
{
    private static PlayerDataLoaderScript instance;
    public static PlayerDataLoaderScript Instance
    {
    get { return instance; }
    }

    [SerializeField] List<string> GameNames;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        CheckData();
    }



    public void CheckData()
    {
        //AlreadyHasData would be the checker 0 false 1 true;
        if (PlayerPrefs.HasKey("AlreadyHasData"))
        {
            Debug.Log("Success with data");
        }
        else
        {
            Debug.Log("No data yet, Adding data");
            PlayerPrefs.SetInt("AlreadyHasData", 1);
            foreach (string name in GameNames)
            {
                Debug.Log(name);
                PlayerPrefs.SetInt(name, 0); }
                PlayerPrefs.Save();
        }
        
    }


    public void SaveGameData(string GameName,int GameScore)
    {
        PlayerPrefs.SetInt(GameName, GameScore);
        PlayerPrefs.Save();
    }

    public int GetData(string GameName)
    {
        return PlayerPrefs.GetInt(GameName);
    }

}
