using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Attack_Box2 : MonoBehaviour {


	GameObject[] row3_towers;
    int EnemyCounter;

    void FixedUpdate()
    {

        row3_towers = GameObject.FindGameObjectsWithTag("row3_tower");
        if (EnemyCounter > 0)
        {
            foreach (GameObject tower in row3_towers)
            {
                if (!tower.gameObject.GetComponent<BugAway_Tower_BASEclass>().attacking)

                    try
                    {
                        tower.gameObject.GetComponent<BugAway_Tower_BASEclass>().StartAttacking();
                    }
                    catch
                    { }
                    }
        }
        else
        {

            try
            {

                foreach (GameObject tower in row3_towers)
                {
                    tower.gameObject.GetComponent<BugAway_Tower_BASEclass>().StopAttacking();
                }
            }
            catch
            {


            }
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.CompareTag("Enemy"))
		{
//			Debug.Log ("Bruh");

            EnemyCounter++;
        }

    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Enemy"))
        {
            EnemyCounter--;
        }


    }


}
