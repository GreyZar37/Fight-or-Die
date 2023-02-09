using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public enum attackType
{
    UpperCut_, mediumCut_, Lowercut_, shoot_
}
public enum player

{
    playerOne, PlayerTwo
}

public class PlayerMovment : MonoBehaviour
{
    public string playerName;
    public Controller control;
    [HideInInspector] public player playerNum;
    public attackType AttackType;
    Transform enemy;

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float attackRadius;

    bool attacking;
    public float stunTimer;

    public int uDamage, mDamage, lDamage;
    int damage;

    public LayerMask ground, enemyLayer;
    public LayerMask P1Mask, P2Mask;


    [SerializeField] Transform legs;
    public bool isgrounded;

    Collider2D enemyCollider;

    public bool stuned;
    int side;

    Animator anim;
    [SerializeField] Health hpScript;
    [SerializeField] Transform UpperCut, mediumCut, Lowercut;


    Vector2 movementInput = Vector2.zero;
    bool jumped, middleCut, upperCut, kick, crouched, shoot;
    [HideInInspector] public bool specialMove;
    public bool block;
    bool stillHoldingBlock;
    float horizontal;

    public int playerID;
    public Transform StartPos;

    [SerializeField] AudioClip[] attackSound;
    [SerializeField] AudioClip[] walkSound;

    [Header("Combo")]
    float windowTimer = 0.3f;
    float windowTimerCold = 0.6f;
    int combo;
    bool exhusted;
    public bool shooting;
    [SerializeField] ParticleSystem sheild;
    [SerializeField] GameObject bullet;
    private void Awake()
    {


        // transform.position = StartPos.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
        if (tag == "P1")
        {
            playerNum = player.playerOne;
        }
        else if (tag == "P2")
        {
            playerNum = player.PlayerTwo;
        }


        if (playerNum == player.playerOne)
        {
            enemy = GameObject.FindGameObjectWithTag("P2").transform;
            enemyLayer.value = P2Mask;

        }
        else if (playerNum == player.PlayerTwo)
        {
            enemy = GameObject.FindGameObjectWithTag("P1").transform;
            enemyLayer.value = P1Mask;
        }


        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(enemyCollider.gameObject.name);
        if (stuned == false)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        if (attacking && isgrounded == true || stuned && isgrounded == true || exhusted && isgrounded == true || GameManager.gameState != gameState.Combat)
        {
            horizontal = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else if (attacking && isgrounded == false)
        {
            horizontal = movementInput.x;
        }


        if (!block)
        {
            sheild.Stop();

        }
        else
        {
            sheild.Play();

        }

        if (windowTimer <= 0)
        {
            combo = 0;
            anim.speed = 1;
        }
        if (combo > 0)
        {
            windowTimer -= Time.deltaTime;
        }

        if (Mathf.Abs(movementInput.x) > 0 || isgrounded == false || attacking)
        {
            block = false;
        }
        else if(stillHoldingBlock == true)
        {
            block = stillHoldingBlock;
        }

        if (attacking == false && stuned == false && exhusted == false && GameManager.gameState == gameState.Combat)
        {
            horizontal = movementInput.x;
            if (jumped)
            {
                jump();
            }

            if (!shooting)
            {
                if (upperCut)
                {
                    AttackType = attackType.UpperCut_;
                    anim.SetTrigger("UpperCut");

                    if (combo == 0)
                    {
                        windowTimer = windowTimerCold * 2;
                        StartCoroutine(attack(AttackType, 1));
                        combo++;

                    }
                    else if (windowTimer > 0 && combo < 3)
                    {
                        windowTimer = windowTimerCold;
                        StartCoroutine(attack(AttackType, 2));
                        combo++;

                    }
                    else
                    {
                        StartCoroutine(attack(AttackType, 1));
                        combo = 0;
                        StartCoroutine(exhustedTime());

                    }





                }
                else if (middleCut)
                {

                    AttackType = attackType.mediumCut_;
                    anim.SetTrigger("MediumCut");
                    if (combo == 0)
                    {
                        windowTimer = windowTimerCold * 2;
                        StartCoroutine(attack(AttackType, 1));
                        combo++;

                    }
                    else if (windowTimer > 0 && combo < 3)
                    {
                        windowTimer = windowTimerCold;
                        StartCoroutine(attack(AttackType, 2));
                        combo++;

                    }
                    else
                    {
                        StartCoroutine(attack(AttackType, 1));
                        combo = 0;
                        StartCoroutine(exhustedTime());
                    }






                }
                else if (kick)
                {

                    AttackType = attackType.Lowercut_;
                    anim.SetTrigger("LowerCut");
                    if (combo == 0)
                    {
                        windowTimer = windowTimerCold * 2;
                        StartCoroutine(attack(AttackType, 1));
                        combo++;

                    }
                    else if (windowTimer > 0 && combo < 3)
                    {
                        print("xD");
                        windowTimer = windowTimerCold;
                        StartCoroutine(attack(AttackType, 2));
                        combo++;

                    }
                    else
                    {
                        StartCoroutine(attack(AttackType, 1));
                        combo = 0;
                        StartCoroutine(exhustedTime());

                    }
                }
                else if (shoot && hpScript.currentStamina > 20 )
                {
                    StartCoroutine(fireJolt());
                }
            }
           
        }

        anim.SetFloat("Velocity", Mathf.Abs(horizontal));


        isgrounded = Physics2D.OverlapCircle(legs.transform.position, 0.1f, ground);





        if ((transform.position.x - enemy.transform.position.x) > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            side = -1;

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            side = 1;
        }






        if (isgrounded)
        {
            rb.gravityScale = 6;

        }




    }

    void jump()
    {
        if (isgrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    IEnumerator fireJolt()
    {
        shooting = true;
        hpScript.currentStamina -= 20;
        if (side > 0)
        {
            Instantiate(bullet, mediumCut.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(bullet, mediumCut.position, Quaternion.Euler(0, 180, 0));

        }

        yield return new WaitForSeconds(1f);
        shooting = false;
    }
    IEnumerator attack(attackType type, float animMultiplier)
    {

        AudioManager.instance.playSound(attackSound, 1);
        attacking = true;
        anim.speed = 1 * animMultiplier;
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length / 2);


        switch (type)
        {

            case attackType.UpperCut_:
                enemyCollider = Physics2D.OverlapCircle(UpperCut.position, attackRadius, enemyLayer);
                if (enemyCollider != null)
                {
                    enemyCollider.GetComponent<Health>().stun(0.5f);


                    enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 20), ForceMode2D.Impulse);
                    enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 1;

                }

                damage = uDamage;

                break;
            case attackType.mediumCut_:
                enemyCollider = Physics2D.OverlapCircle(mediumCut.position, attackRadius, enemyLayer);

                if (enemyCollider != null)
                {
                    enemyCollider.GetComponent<Health>().stun(0.5f);

                    if (enemyCollider.GetComponent<PlayerMovment>().isgrounded == false)
                    {

                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * side, 15), ForceMode2D.Impulse);


                    }
                    else
                    {
                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * side, 0), ForceMode2D.Impulse);

                    }
                }


                damage = mDamage;
                break;
            case attackType.Lowercut_:
                enemyCollider = Physics2D.OverlapCircle(Lowercut.position, attackRadius, enemyLayer);

                if (enemyCollider != null)
                {
                    enemyCollider.GetComponent<Health>().stun(0.5f);


                    if (isgrounded == false)
                    {

                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 25), ForceMode2D.Impulse);


                    }
                    else
                    {
                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(2 * side, 0), ForceMode2D.Impulse);

                    }
                }

                damage = lDamage;
                break;
            default:
                break;


        }



        if (enemyCollider != null)
        {

            enemyCollider.GetComponent<PlayerMovment>().StopAllCoroutines();
            enemyCollider.GetComponent<PlayerMovment>().attacking = false;
            enemyCollider.GetComponent<PlayerMovment>().exhusted = false;
            enemyCollider.GetComponent<PlayerMovment>().shooting = false;
            StartCoroutine(enemyCollider.GetComponent<Health>().takeDamage(damage));
            hpScript.currentStamina += damage;
        }

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length / 2);

        attacking = false;


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(UpperCut.position, attackRadius);
        Gizmos.DrawWireSphere(mediumCut.position, attackRadius);
        Gizmos.DrawWireSphere(Lowercut.position, attackRadius);
    }



    private void OnDisable()
    {
        control.Disable();
    }

    private void OnEnable()
    {
        control = new Controller();
        control.Enable();

    }

    #region

    public void OnBlock(InputAction.CallbackContext context)
    {
        stillHoldingBlock = context.action.triggered;
        if (movementInput.x == 0 && attacking == false && stuned == false && isgrounded == true)
        { 
            block = context.action.triggered;
        }

    }
    public void OnUppercut(InputAction.CallbackContext context)
    {
        upperCut = context.action.triggered;

    }
    public void OnMediumcut(InputAction.CallbackContext context)
    {
        middleCut = context.action.triggered;


    }
    public void OnKick(InputAction.CallbackContext context)
    {
        kick = context.action.triggered;

    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        crouched = context.action.triggered;

    }
    public void Shoot(InputAction.CallbackContext context)
    {
        shoot = context.action.triggered;
    }
   

    #endregion

    IEnumerator exhustedTime()
    {
        exhusted = true;

        yield return new WaitForSeconds(1);
        exhusted = false;
    }

    public void playWalkSound()
    {
        AudioManager.instance.playSound(walkSound, 1);
    }
}
