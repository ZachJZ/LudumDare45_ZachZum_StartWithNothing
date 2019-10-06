using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideOnStart : MonoBehaviour
{

    public GameObject heart;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
            //if (Input.GetKeyDown(KeyCode.G))
        {
            heart.GetComponent<Image>().enabled = false;
        }
    }
}
