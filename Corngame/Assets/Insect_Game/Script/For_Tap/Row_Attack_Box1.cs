using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Attack_Box1 : MonoBehaviour {


	GameObject[] row2_towers;
	int EnemyCounter;

	void FixedUpdate()
	{

        row2_towers = GameObject.FindGameObjectsWithTag("row2_tower");
        if (EnemyCounter > 0)
        {
            foreach (GameObject tower in row2_towers)
            {
                if (!tower.gameObject.GetComponent<BugAway_Tower_BASEclass>().attacking)
                    try
                    {
                        tower.gameObject.GetComponent<BugAway_Tower_BASEclass>().StartAttacking();
                    }
                    catch
                    {}
                    }
        }
        else
        {

            try
            {

                foreach (GameObject tower in row2_towers)
                {
                    tower.gameObject.GetComponent<BugAway_Tower_BASEclass>().StopAttacking();
                }
            }
            catch
            {


            }
        }

    }

		void OnTriggerEnter2D(Collider2D c) {

        if (c.CompareTag("Enemy"))
        {
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
