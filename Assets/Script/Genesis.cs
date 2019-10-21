using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genesis : MonoBehaviour
{
    public GameObject Block;

    public GameObject Player;

    public GameObject HUD;


    private CountingMain myCounter;
    private PlayerController myPLayer;
    private bool StartingLine;

    // Start is called before the first frame update
    void Start()
    {
        myCounter = FindObjectOfType<CountingMain>();
        myPLayer = FindObjectOfType<PlayerController>();

        Player.SetActive(false);
        HUD.SetActive(false);
        Block.SetActive(true);
        GetComponent<HUD_Lab1>().enabled = false;

        StartingLine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCounter.GetExperience() == 10 && StartingLine == false)
        {
            Player.SetActive(true);
            HUD.SetActive(true);
            GetComponent<HUD_Lab1>().enabled = true;

            Block.SetActive(false);

myPLayer.CreateHealthIcons(5);
            StartingLine = true;
            //Player.GetComponent<PlayerController>().enabled = false;
            // StartCoroutine("EnableHim");
        }
    }

    //IEnumerator EnableHim()
    //{
    //    new WaitForSeconds(5f);
    //    Player.GetComponent<PlayerController>().enabled = true;

    //    yield return new WaitForSeconds(1);

    //}
}
