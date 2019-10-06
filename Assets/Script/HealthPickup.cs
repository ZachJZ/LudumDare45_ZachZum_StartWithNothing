using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerController myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerController>())
        {
            //print("Slime was hit");
            myPlayer.HealPlayer();
            Destroy(gameObject);
            print("heart did the thing");
        }
    }

}
