using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myAnimController : MonoBehaviour
{

    PlayerController myPlayer;

    public Collider2D HitBox;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerController>();
    }

    void DoneAttack()
    {
        myPlayer.AttackOff();
    }

    void StopAttack()
    {
        myPlayer.AttackStop();
        print("Stop attack is activated in the anim script");
    }

    void HitBoxOn()
    {
        if (!HitBox.enabled)
        {
            HitBox.enabled = true;
        }
    }

    void HitBoxOff()
    {
        if (HitBox.enabled)
        {
            HitBox.enabled = false;

        }
    }

}
