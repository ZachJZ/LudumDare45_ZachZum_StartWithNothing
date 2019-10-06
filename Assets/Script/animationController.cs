using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{

    PlayerController myPlayer;

    // Start is called before the first frame update
    void Start()
    {

        myPlayer = FindObjectOfType<PlayerController>();
        
    }

    void DoneAttack()
    {
        myPlayer.AttackOff();
    }
}
