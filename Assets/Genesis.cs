using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genesis : MonoBehaviour
{
    public GameObject Block;

    public GameObject Player;

    public GameObject HUD;


    private CountingMain myCounter;

    // Start is called before the first frame update
    void Start()
    {
        myCounter = FindObjectOfType<CountingMain>();

        Player.SetActive(false);
        HUD.SetActive(false);
        Block.SetActive(true);
        GetComponent<HUD_Lab1>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCounter.GetExperience() >= 10)
        {
            Player.SetActive(true);
            HUD.SetActive(true);
            GetComponent<HUD_Lab1>().enabled = true;

            Block.SetActive(false);

            //Player.GetComponent<PlayerController>().enabled = false;
            StartCoroutine("EnableHim");
        }
    }

    IEnumerator EnableHim()
    {
        new WaitForSeconds(5f);
        Player.GetComponent<PlayerController>().enabled = true;

        yield return new WaitForSeconds(1);

    }
}
