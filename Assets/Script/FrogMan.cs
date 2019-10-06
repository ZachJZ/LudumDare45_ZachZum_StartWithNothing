using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMan : MonoBehaviour
{
    //public AudioSource boomBox;
    //public AudioClip CD;
    //sounds
    public AudioSource hPickUp, playerHurt, slimeHurt, slimeSquish, swordSwish, swordTing, clubBonk, sadChord, winChord;
    //    private List<HealthCounter_Lab1> HCInst;

    // Start is called before the first frame update
    void Start()
    {
        //CD = boomBox.GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPickUp()
    {
        hPickUp.Play();
    }
    public void playPlayerHurt() {
        playerHurt.Play();
    }
    public void playSlimeHurt() {
        slimeHurt.Play();
    }

    public void playSlimeSquish() {
        slimeSquish.Play();
    }
    public void playSwordSwish() {
        swordSwish.Play();
    }
    public void playSwordTing() {
        swordTing.Play();
    }
    public void playClubBonk() {
        clubBonk.Play();
    }
    public void playSadChord() {
        sadChord.Play();
    }
    public void playWinChord() {
        winChord.Play();
    }
}
