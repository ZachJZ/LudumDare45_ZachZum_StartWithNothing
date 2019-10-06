using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    [SerializeField]
    private CountingMain myCounter;
    private PlayerController myPlayer;
    private int Difficulty;

    public GameObject Heart;

    public Color myGreen;
    public Color myRed;
    public Color myBlue;

    [Header("Stats")]
    [SerializeField]
    private int Fuse;
    [SerializeField]
    private int Dex;
    [SerializeField]
    private int Str;
    [SerializeField]
    private int MaxHP;
    private int HP;
    [SerializeField]
    private int JumpPow;
    private int EXP;

    [SerializeField]
    private int Intel;
    [SerializeField]
    private float Timer;

    private int randomSlime;

    private Rigidbody2D rb;

    public BoxCollider2D HitBox; //not trigger
    public BoxCollider2D HurtBox; //trigger

    int drop;

    private FrogMan myDJ;



    // Start is called before the first frame update
    void Start()
    {
        //private FrogMan myDJ;
        myDJ = FindObjectOfType<FrogMan>();

    myCounter = FindObjectOfType<CountingMain>();
        myPlayer = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        if (!name.Contains("Green") && !name.Contains("Blue") && !name.Contains("Red"))
        {
            SlimeAssignment();
        }

        if (name.Contains("Green"))
        {
            //color green
            GetComponent<Renderer>().material.color = myGreen;
            Fuse = Random.Range(3,6);
            Str = 1;
            Dex = Random.Range(45, 60);
            MaxHP = Random.Range(1,4);
            EXP = MaxHP += Str;
            JumpPow = Random.Range(2, 3);

            //print("Slme is green");

        }

        else if (name.Contains("Blue"))
        {
            //color blue
            //more big jumps
            GetComponent<Renderer>().material.color = myBlue;
            Fuse = Random.Range(2,5);
            Str = 2;
            Dex = Random.Range(90,110);
            MaxHP = Random.Range(5,9);
            EXP = MaxHP += Str;
            JumpPow = Random.Range(3, 5);
            //print("Slme is blue");

        }

        else if (name.Contains("Red"))
        {
            //color red
            //more aggressive
            GetComponent<Renderer>().material.color = myRed;
            Fuse = Random.Range(1,3);
            Str = 3;
            Dex = Random.Range(70, 85);
            MaxHP = Random.Range(8,15);
            EXP = MaxHP += Str;
            JumpPow = Random.Range(3, 4);
            //print("Slme is red");
        }

        else
        {
            //randomize?
            Debug.LogError("Something went wrong. The slime was not assigned a color, and a color was not detected");

        }

        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Difficulty = myCounter.GetExperience();

        Timer += Time.deltaTime;

        //hp check
        if (HP <= 0)
        {
            SlimeDeath();
        }

        if (Timer >= Fuse)
        {
            Intel = Random.Range(0, 7);
            //print("Intel is " + Intel);

            if (Intel >= 0 && Intel <= 3)
            {
                if (Intel == 1 || Intel == 0)
                {
                    Jump(true);
                    Timer = 0;
                }
                if (Intel == 2 || Intel == 3)
                {
                    Jump(false);
                    Timer = 0;
                }
            }

            if (Intel >= 4 && Intel <= 7)
            {
                if (Intel == 4 || Intel == 5)
                {
                    BigJump(true);
                    Timer = 0;
                }
                if (Intel == 6 || Intel == 7)
                {
                    BigJump(false);
                    Timer = 0;
                }

            }

        }
    }

    void SlimeAssignment()
    {
        randomSlime = Random.Range(0, 5);


        if (Difficulty < 100)
        {
            if (randomSlime == 0)
            {
                name = "Red";
            }

            else if (randomSlime == 1 || randomSlime == 2)
            {
                name = "Blue";
            }

            else
            {
                name = "Green";
            }
        }

        else if (Difficulty >= 100 && randomSlime < 200)
        {
            if (randomSlime == 0)
            {
                name = "Red";
            }

            else if (randomSlime == 1 || randomSlime == 2)
            {
                name = "Green";
            }

            else
            {
                name = "Blue";
            }
        }

        else
        {
            if (randomSlime == 0)
            {
                name = "Green";
            }

            else if (randomSlime == 1 || randomSlime == 2)
            {
                name = "Blue";
            }

            else
            {
                name = "Red";
            }
        }
    }

    void SlimeDeath()
    {
        //give xp
        myCounter.ModExperience(EXP);
        print("exp is " + EXP);

        //play death sound
        //myDJ.playSlimeSquish();
        drop = Random.Range(1, 20);
        if (drop > 8)
        {
            //spawn heart
            Instantiate(Heart, transform.position, transform.rotation );
            //print("made a heart ... maybe");
        }
        //delet this :gun:
        Destroy(gameObject);
    }

    void Jump(bool Right)
    {
        if (Right)
        {
            //Jump Right
            rb.AddForce(new Vector2(Dex, Dex * 2));
         //   myDJ.playSlimeHurt();


        }

        else
        {
            //Jump Left
            rb.AddForce(new Vector2(-Dex, Dex * 2));

        }
    }

    void BigJump(bool Right)
    {
        if (Right)
        {
            //Jump Right
            rb.AddForce(new Vector2(Dex, Dex * JumpPow));
        }
        else
        {
            //Jump Left
            rb.AddForce(new Vector2(-Dex, Dex * JumpPow));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //print("collider is " + col.gameObject.name);
        //if (col.name == "Sword" || col.name == "Club")
        if (col.GetComponent<Assault>())
        {
            //print("Slime was hit");
            HP -= myCounter.GetPower();

            if ((col.transform.position.x - transform.position.x) > 0)
            {
                //send left
                rb.AddForce(new Vector2(-Dex, JumpPow * 2));
                print("X is greater, jumping left");
            }

            else if ((col.transform.position.x - transform.position.x) < 0)
            { 
                rb.AddForce(new Vector2(Dex, JumpPow * 2));
                print("X is greater, jumping right");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //print("collider is " + col.gameObject.name);

        if (col.gameObject.name == "Hero")
        {
            //print("Slime hit hero");
            myPlayer.DamagePlayer();
            //Damage hero
            //knock back hero?
        }
    }
}
