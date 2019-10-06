using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject WinScreen;

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

    [SerializeField]
    private GameObject myMessage;
    private bool MessageOn;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float messageTime;

    // Start is called before the first frame update
    void Start()
    {
        myMessage.SetActive(false);
        counterDataScript = GameObject.FindObjectOfType<CountingMain>().GetComponent<CountingMain>();
        myPlayer.GetComponent<SpriteRenderer>().sprite = naked;
        timer = 0;
        if(messageTime == 0)
        {
            messageTime = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (MessageOn)
        {
            timer += Time.deltaTime;
        }

        ClickCounter();

        if (counterDataScript.GetExperience() == 10)
        {
            counterDataScript.TextShrink();
            counterDataScript.MoveTextToCorner();
            counterDataScript.SetPower(2);
            Cursor.visible = false;
        }

        if (counterDataScript.GetExperience() >= 14 && counterDataScript.GetExperience() <= 50)
        {
            if (myPlayer.GetComponent<SpriteRenderer>().sprite != hunter)
            {
                myPlayer.GetComponent<SpriteRenderer>().sprite = hunter;
                Popup("Clothes Acquired");
            }

            //CLOTHES GET popup

        }

        if (counterDataScript.GetExperience() >= 100 && counterDataScript.GetExperience() <= 150)
        {
            if (mySword.activeInHierarchy == false)
            {
                //StartCoroutine
                Popup("Sword Acquired");
                mySword.SetActive(true);
                //SWORD GET popup
                myClub.SetActive(false);
            }
        }

        if (counterDataScript.GetExperience() == 200)
        {
            if (myPlayer.GetComponent<SpriteRenderer>().sprite != knight)
            {
                Popup("Armor Acquired");
                myPlayer.GetComponent<SpriteRenderer>().sprite = knight;
            }
        }

        if (counterDataScript.GetExperience() == 500)
        {
            Popup("YOU WIN!");
            Cursor.visible = true;
            //WIN
            ZAWARDO();
            WinScreen.SetActive(true);
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

    void Popup(string popUp)
    {
        StartCoroutine(ShowMessage(popUp, 3));

        //myMessage.SetActive(true);
        //MessageOn = true;
        //myMessage.GetComponentInChildren<Text>().text = popUp;
        //if (timer >= messageTime)
        //{
        //    print("the thing is happenning");
        //    myMessage.GetComponentInChildren<Text>().text = "";
        //    MessageOn = false;
        //    timer = 0;
        //    myMessage.SetActive(false);
        //}
    }

    void ZAWARDO()
    {
        StartCoroutine(ScaleTime(1.0f, 0.0f, 3.0f));
    }    

    IEnumerator ShowMessage(string message, float delay)
    {
        print("the thing is happenning");

        myMessage.SetActive(true);
        myMessage.GetComponentInChildren<Text>().text = message;

        yield return new WaitForSeconds(delay);
        myMessage.GetComponentInChildren<Text>().text = "";
        myMessage.SetActive(false);
    }


IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = end;
    }

}
