using UnityEngine;
using System.Collections;

public class rankCalculation : MonoBehaviour 
{

	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        int points = (GameObject.Find("Player").GetComponent<PlayerScript>().getPointsCount());
        if (points >= 15 && points < 30)
        {
            giveRank(1);
        }
        else if (points >= 30 && points < 50)
        {
            giveRank(2);
        }
        else if (points >= 50)
        {
            giveRank(3);
        }
	}


    void giveRank(int rank)
    {
        for (int i = 0; i < rank; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
