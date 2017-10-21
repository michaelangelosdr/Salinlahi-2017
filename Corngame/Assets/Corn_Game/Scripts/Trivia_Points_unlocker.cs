using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trivia_Points_unlocker : MonoBehaviour {

    public int ScoreNeeded;
    public GameObject blocker;

    public void Unlocker(int Score)
    {
        if(Score>=ScoreNeeded)
        {
            blocker.SetActive(false);
        }
    }

   
}
