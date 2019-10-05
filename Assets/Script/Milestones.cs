using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milestones : MonoBehaviour
{
    /* PROGRESSION NUMBERS
     * 10 - orbiters
     * 100 - born
     * >Slime kill - club
     * 200 - clothes
     * 360 - sword
     * 500 - 
     * 777
     * 1337
     * 4400
     * 7777
     * 9999
     * 
     * 
     * 0-500
     */

    private CountingMain counterDataScript;

    // Start is called before the first frame update
    void Start()
    {
        counterDataScript = GameObject.FindObjectOfType<CountingMain>().GetComponent<CountingMain>();
    }

    // Update is called once per frame
    void Update()
    {
        ClickCounter();

        if (counterDataScript.GetExperience() == 10)
        {
            counterDataScript.TextShrink();
            counterDataScript.MoveTextToCorner();
            counterDataScript.SetPower(2);
        }

        //if (counterDataScript.GetExperience() == 20 || counterDataScript.GetExperience() == 30)
        //{
        //    counterDataScript.TextShake();
        //}

    }

    void ClickCounter()
    {
        //Input subject to change
        if (Input.GetMouseButtonDown(0))
        {
            counterDataScript.ModExperience(counterDataScript.GetPower());
            if (counterDataScript.GetExperience() < 10 || counterDataScript.GetExperience() == 20)
            {
                counterDataScript.TextShake();
            }
        }
    }

}
