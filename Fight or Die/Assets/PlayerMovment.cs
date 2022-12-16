using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum attackType
{
    UpperCut_, mediumCut_, Lowercut_
}
public enum player

{
    playerOne, PlayerTwo
}
public class PlayerMovment : MonoBehaviour
{
    public player playerNum;
    public attackType AttackType;
   [SerializeField] Transform enemy;
    [SerializeField] string playerNumber;

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float attackRadius;

    bool attacking;
    public float attackCooldown;
    float currentTimer;
    public float stunTimer;

    public int uDamage, mDamage, lDamage;
    int damage;

    [SerializeField] LayerMask ground, enemyLayer;
    [SerializeField] Transform legs;
    public bool isgrounded;

    float horizontal;
    Collider2D enemyCollider;

    public bool stuned;
    int side;

    Animator anim;
    [SerializeField] Health hpScript;

   [SerializeField] Transform UpperCut, mediumCut, Lowercut;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            if(attacking == false && stuned == false && GameManager.gameState == gameState.Combat)
            {
                horizontal = Input.GetAxisRaw("Horizontal" + playerNumber);
                if (Input.GetButtonDown("Jump" + playerNumber))
                {
                    jump();
                }

                if (Input.GetButtonDown("UpperCut" + playerNumber))
                {
                    AttackType = attackType.UpperCut_;
                    anim.SetTrigger("UpperCut");

                    attack(AttackType);

                }
                else if (Input.GetButtonDown("MediumCut" + playerNumber))
                {
                    AttackType = attackType.mediumCut_;
                    anim.SetTrigger("MediumCut");

                    attack(AttackType);

                }
                else if (Input.GetButtonDown("LowerCut" + playerNumber))
                {

                    AttackType = attackType.Lowercut_;
                    anim.SetTrigger("LowerCut");

                    attack(AttackType);

                }
                else if(Input.GetAxisRaw("Jump" + playerNumber) > 0.7f)
                {
                    jump();
                }





        }
        /*
        else
        {
            if (attacking == false && stuned == false && GameManager.gameState == gameState.Combat)
            {
                horizontal = Input.GetAxisRaw("HorizontalP2");

                if (Input.GetAxisRaw("JumpP2") > 0.7f)
                {
                    jump();
                }

                if (Input.GetButtonDown("UpperCutP2"))
                {
                    AttackType = attackType.UpperCut_;
                    anim.SetTrigger("UpperCut");
                    print("U");

                    attack(AttackType);
                }
                else if (Input.GetButtonDown("MediumCutP2"))
                {
                    AttackType = attackType.mediumCut_;
                    anim.SetTrigger("MediumCut");
                    print("M");

                    attack(AttackType);

                }
                else if (Input.GetButtonDown("LowerCutP2"))
                {

                    AttackType = attackType.Lowercut_;
                    anim.SetTrigger("LowerCut");
                    print("L");

                    attack(AttackType);

                }
            }
          
          
        }
        */
        anim.SetFloat("Velocity", Mathf.Abs(horizontal));


        isgrounded = Physics2D.OverlapCircle(legs.transform.position, 0.1f, ground);

        if(stuned == false || isgrounded)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        }
        else if (stuned == true && isgrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }

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

        if (currentTimer >= 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            attacking = false;
        }

        if (attacking && isgrounded == true ||stuned && isgrounded == true)
        {
            horizontal = 0;
        }
        else
        {
            horizontal = 0;
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
   
    void attack(attackType type)
    {
        if(currentTimer <= 0)
        {
            attacking = true;
            switch (type)
            {

                case attackType.UpperCut_:
                    enemyCollider = Physics2D.OverlapCircle(UpperCut.position, attackRadius, enemyLayer);
                    if (enemyCollider != null)
                    {
                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 20), ForceMode2D.Impulse);
                        enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 1;

                    }

                    damage = uDamage;

                    break;
                case attackType.mediumCut_:
                    enemyCollider = Physics2D.OverlapCircle(mediumCut.position, attackRadius, enemyLayer);

                    if (enemyCollider != null)
                    {
                        enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 1;

                        if (enemyCollider.GetComponent<PlayerMovment>().isgrounded == false)
                        {

                            enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(2 * side, 15), ForceMode2D.Impulse);


                        }
                        else
                        {
                            enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(15 * side, 0), ForceMode2D.Impulse);

                        }
                    }
                   

                    damage = mDamage;
                    break;
                case attackType.Lowercut_:
                    enemyCollider = Physics2D.OverlapCircle(Lowercut.position, attackRadius, enemyLayer);

                    if (enemyCollider != null)
                    {
                        enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 1;


                        if (isgrounded == false)
                        {

                            enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 25), ForceMode2D.Impulse);


                        }
                        else
                        {
                            enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(20 * side, 0), ForceMode2D.Impulse);

                        }
                    }
                 
                    damage = lDamage;
                    break;
                default:
                    break;
            }
            if(enemyCollider != null)
            {
              StartCoroutine(enemyCollider.GetComponent<Health>().takeDamage(damage));
                hpScript.currentStamina += damage;

            }
            currentTimer = attackCooldown;
        }
     
      

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(UpperCut.position, attackRadius);
        Gizmos.DrawWireSphere(mediumCut.position, attackRadius);
        Gizmos.DrawWireSphere(Lowercut.position, attackRadius);
    }
}
