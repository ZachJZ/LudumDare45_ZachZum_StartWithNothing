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

    public Sprite naked;
    public Sprite hunter;
    public Sprite knight;

    int test = 0;

    private CountingMain counterDataScript;

    [SerializeField]
    private GameObject myPlayer;
    [SerializeField]
    private GameObject myClub;
    [SerializeField]
    private GameObject mySword;

    // Start is called before the first frame update
    void Start()
    {
        counterDataScript = GameObject.FindObjectOfType<CountingMain>().GetComponent<CountingMain>();
        myPlayer.GetComponent<SpriteRenderer>().sprite = naked;
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

        if (counterDataScript.GetExperience() == 30)
        {
            myPlayer.GetComponent<SpriteRenderer>().sprite = hunter;
            //CLOTHES GET popup

        }

        if (counterDataScript.GetExperience() == 100)
        {
            mySword.SetActive(true);
            //SWORD GET popup
            myClub.SetActive(false);
        }

        if (counterDataScript.GetExperience() == 200)
        {
            myPlayer.GetComponent<SpriteRenderer>().sprite = knight;
        }

        if (counterDataScript.GetExperience() == 500)
        {
            //WIN
        }



    }

    void ClickCounter()
    {
        //Input subject to change
        if (Input.GetMouseButtonDown(0) && counterDataScript.GetExperience() <= 10)
        {
            //test++;
            //print(test);
            counterDataScript.ModExperience(counterDataScript.GetPower());
            if (counterDataScript.GetExperience() < 10 || counterDataScript.GetExperience() == 20 || counterDataScript.GetExperience() == 50 || counterDataScript.GetExperience() == 100 || counterDataScript.GetExperience() == 200 || counterDataScript.GetExperience() == 400 || counterDataScript.GetExperience() == 500)
            {
                counterDataScript.TextShake();
            }
        }

        //when you get a kill you get xp
        //xp makes your power go up
        //eventually knights spawn?
       // else if ()
    }

}
