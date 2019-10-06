
//==================================================================
// Author:  Zachary ZumTobel
// Last Edit Date:  12-05-2016
// Credit: https://drive.google.com/file/d/0BwzCd4sqjczBM0FDZWRQcVR0N2s/view?pli=1 
// Credit: https://unity3d.com/learn/tutorials/topics/scripting/loops
// Credit: https://unity3d.com/learn/tutorials/topics/scripting/switch-statements
// Credit: http://answers.unity3d.com/questions/574110/how-do-i-access-a-public-float-from-another-script.html
//
// Purpose: The brain of the heads-up display features: ammo, lives, 
//          shield, and score.
//          Creates and keeps track of the numbers of each of these variables.
//
//==================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HUD_Lab1 : MonoBehaviour {

    public HealthCounter_Lab1 healthCounter;
    private List<HealthCounter_Lab1> HCInst;

    private float difference;

    public GameObject Begin;
    public GameObject Target;

    // Use this for initialization
    void Start ()
    {
        difference = Begin.GetComponent<RectTransform>().position.x - Target.GetComponent<RectTransform>().position.x;

        CreateHealthIcons(4);
        //updateHealth(4);
        //print("begi: " + Begin.GetComponent<RectTransform>().position.x);
        //print("targ: " + Target.GetComponent<RectTransform>().position.x);

        //print("Local begi: " + Begin.GetComponent<RectTransform>().localPosition.x);
        //print("Local targ: " + Target.GetComponent<RectTransform>().localPosition.x);


        //print("diff: " + difference);
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
    //Function for creating the other Life/Lives icons

        //Function for creating the other Health Tokens
    public void CreateHealthIcons(int numHealth)
    {
        print(difference);
            //Check to see if the list is empty
        if (HCInst == null)
        {
                //Creates a new list
            HCInst = new List<HealthCounter_Lab1>();

            //
            HCInst.Add(healthCounter);
                //Sets the space between each new icon
            Vector3 positionOffSet = new Vector3(-difference, 0f, 0f);
            print("PosOff " + positionOffSet);


            //
            for (int i = 1; i < numHealth; ++i)
            {

                //Sets the script to a usable variable
                HealthCounter_Lab1 newHealth;
                    //Creates new healthCounter and sets position and rotation
                newHealth = Instantiate(healthCounter, healthCounter.transform.position, healthCounter.transform.rotation, FindObjectOfType<Canvas>().transform) as HealthCounter_Lab1;
                newHealth.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);


                //Sets value of newPosition to where the first icon was created
                Vector3 newPosition = newHealth.transform.position;
                    //Sets position based off of number of icons created
                newPosition.x += (positionOffSet.x * i);
                    //Places icon at appropriate position
                newHealth.transform.position = newPosition;
                    //Makes sure each new icon is in a uniform scale
                newHealth.transform.localScale = new Vector3(1f, 1f, 1f);

                    //Adds counter to list
                HCInst.Add(newHealth);
            }
        }
    }

        //Function that sets active the correct number of Health icons
    public void updateHealth(int numHealth)
    {
            //Runs through a number of times equal to the size of the list
        for (int i = 0; i < HCInst.Count; i++)
        {
                //Sets active each icon that is to be used
            bool bActivate = i < numHealth;
            HCInst[i].gameObject.SetActive(bActivate);

        }
    }

}
