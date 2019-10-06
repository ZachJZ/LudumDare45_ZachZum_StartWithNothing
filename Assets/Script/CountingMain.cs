using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountingMain : MonoBehaviour
{

    //Variables
    [SerializeField]
    private int myExperience;
    private float mySpeed = 300;
    private int myPower;

    //Gameobjects
    [SerializeField]
    private Text myCounter;

    public GameObject CounterText;
    public GameObject CounterStartPos;
    public GameObject CounterTargetPos;
         

    // Start is called before the first frame update
    void Start()
    {
        myExperience = 0;
        myPower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        myCounter.text = "" + myExperience + "";
        //ClickCounter();

        //if (myExperience == 10)
        //{
        //    MoveTextToCorner();
        //    SetPower(2);
        //}

    }

    public void TextShake()
    {
        StartCoroutine(ShakeCR());
    }

    public void TextShrink()
    {
        StartCoroutine(ShrinkCR());
    }


    public void MoveTextToCorner()
    {
        StartCoroutine(CounterMovingCR());
    }

    IEnumerator CounterMovingCR()
    {
        while (true)
        {
            while (Vector3.Distance(CounterText.transform.position, CounterTargetPos.transform.position) > 0)
            {
                CounterText.transform.position = Vector3.MoveTowards(CounterText.transform.position, CounterTargetPos.transform.position, Time.deltaTime * mySpeed);
                yield return new WaitForSeconds(0.02f);

            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator ShakeCR()
    {
        float startSize;
        startSize = myCounter.fontSize;

        myCounter.fontSize = myCounter.fontSize + 20;

        while (myCounter.fontSize > startSize)
        {
            myCounter.fontSize--;
            yield return new WaitForSeconds(0.05f);

        }
        yield return new WaitForSeconds(1f);
    }

    IEnumerator ShrinkCR()
    {
        while (myCounter.fontSize > 28)
        {
            myCounter.fontSize--;
            yield return new WaitForSeconds(0.01f);

        }
        yield return new WaitForSeconds(1f);

    }


    //SETTERS AND GETTERS

    public void SetExperience(int SetTo)
    {
        myExperience = SetTo;
        //print("Setting Experience " + SetTo);

    }

    public void SetPower (int SetTo)
    {
        myPower = SetTo;
    }

    public void ModExperience(int modBy)
    {
        //print("Experience is " + myExperience + ". Modifying it by " + modBy);
        myExperience += modBy;
        //print("Experience is now " + myExperience);
    }

    public void ModPower (int modBy)
    {
        myPower += modBy;
    }

    public int GetExperience()
    {
        return myExperience;
    }

    public int GetPower()
    {
        return myPower;
    }

}
