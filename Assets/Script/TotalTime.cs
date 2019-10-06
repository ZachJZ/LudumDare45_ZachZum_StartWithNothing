using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TotalTime : MonoBehaviour
{
    //text
    [SerializeField]
    private Text myClock;
    //display
    [SerializeField]
    private int DisplayNum;
    //timer
    [SerializeField]
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        myClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        DisplayNum = Mathf.RoundToInt(timer);

        myClock.text = DisplayNum.ToString(); 

    }
}
