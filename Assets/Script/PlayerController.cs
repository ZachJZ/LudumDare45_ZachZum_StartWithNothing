using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*
     * W - Weapon charge up
     * S - Duck
     * A - Move Left
     * D - Move Right
     * Space - Jump
     * LMB - Swing
     * RMB- Stab/Jab
     * 
     */

    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    //public float lowJumpMultiplier = 2f;

    private int pHealth;


    public Animator clubAnim;
    public Animator swordAnim;
    public CharacterController2D myController;

    private float horizontalMove = 0f;
    public float runSpeed = 60.0f;
    private bool jump = false;

    private bool attackCheck;

    void Start()
    {
        pHealth = 4;

        rb = GetComponent<Rigidbody2D>();

        attackCheck = clubAnim.GetBool("doAttack");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            swordAnim.SetBool("ClickHeld", true);
            swordAnim.SetBool("AttackNow", true);

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            swordAnim.SetBool("ClickHeld", false);

            swordAnim.SetBool("AttackNow", false);
            print("Attack stop activated");

        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonUp("Jump"))
        {
            rb.AddForce(Vector2.down /** Physics2D.gravity.y*/ * fallMultiplier * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(0))
        {
            clubAnim.SetBool("doAttack", true);
        }

    }

    void FixedUpdate()
    {   
        myController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void AttackOff()
    {
        clubAnim.SetBool("doAttack", false);
    }

    public void AttackStop()
    {
        swordAnim.SetBool("AttackNow", false);
        print("Attack stop activated");

    }
}
