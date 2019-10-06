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
    [SerializeField]
    private GameObject[] pHearts;


    public Animator clubAnim;
    public Animator swordAnim;
    public CharacterController2D myController;

    private float horizontalMove = 0f;
    public float runSpeed = 60.0f;
    private bool jump = false;

    private bool attackCheck;

    //private List<HealthCounter_Lab1> HCInst;
    //public HealthCounter_Lab1 healthCounter;


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

    //void StartPlayerHealth()
    //{
    //    pHearts[0].SetActive(true);
    //    pHearts[1].SetActive(true);
    //    pHearts[2].SetActive(true);
    //    pHearts[3].SetActive(true);
    //}

    void DamagePlayer()
    {

    }

    //public void CreateHealthIcons(int numHealth)
    //{
    //    //Check to see if the list is empty
    //    if (HCInst == null)
    //    {
    //        //Creates a new list
    //        HCInst = new List<HealthCounter_Lab1>();
    //        //
    //        HCInst.Add(healthCounter);
    //        //Sets the space between each new icon
    //        Vector3 positionOffSet = new Vector3(0.91f, 0f, 0f);

    //        //
    //        for (int i = 1; i < numHealth; ++i)
    //        {
    //            //Sets the script to a usable variable
    //            HealthCounter_Lab1 newHealth;
    //            //Creates new healthCounter and sets position and rotation
    //            newHealth = Instantiate(healthCounter, healthCounter.transform.position, healthCounter.transform.rotation) as HealthCounter_Lab1;

    //            //Sets value of newPosition to where the first icon was created
    //            Vector3 newPosition = newHealth.transform.position;
    //            //Sets position based off of number of icons created
    //            newPosition.x += (positionOffSet.x * i);
    //            //Places icon at appropriate position
    //            newHealth.transform.position = newPosition;
    //            //Makes sure each new icon is in a uniform scale
    //            newHealth.transform.localScale = new Vector3(1f, 1f, 1f);

    //            //Adds counter to list
    //            HCInst.Add(newHealth);
    //        }
    //    }
    //}

    ////Function that sets active the correct number of Health icons
    //public void updateHealth(int numHealth)
    //{
    //    //Runs through a number of times equal to the size of the list
    //    for (int i = 0; i < HCInst.Count; i++)
    //    {
    //        //Sets active each icon that is to be used
    //        bool bActivate = i < numHealth;
    //        HCInst[i].gameObject.SetActive(bActivate);

    //    }
    //}

}
