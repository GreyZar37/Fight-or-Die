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

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float attackRadius;

    bool attacking;
    public float attackCooldown;
    float currentTimer;

    public int uDamage, mDamage, lDamage;
    int damage;

    [SerializeField] LayerMask ground, enemyLayer;
    [SerializeField] Transform legs;
    public bool isgrounded;

    float horizontal;
    Collider2D enemyCollider;

    public bool stuned;
    int side;

   [SerializeField] Transform UpperCut, mediumCut, Lowercut;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNum == player.playerOne)
        {
            if(attacking == false && stuned == false)
            {
                horizontal = Input.GetAxisRaw("HorizontalP1");
                if (Input.GetButtonDown("JumpP1"))
                {
                    jump();
                }

                if (Input.GetButtonDown("UpperCutP1"))
                {
                    AttackType = attackType.UpperCut_;
                    attack(AttackType);

                }
                else if (Input.GetButtonDown("MediumCutP1"))
                {
                    AttackType = attackType.mediumCut_;
                    attack(AttackType);

                }
                else if (Input.GetButtonDown("LowerCutP1"))
                {
                    AttackType = attackType.Lowercut_;
                    attack(AttackType);

                }
            }
          
       

           
        }
        else
        {
            if (attacking == false && stuned == false)
            {
                horizontal = Input.GetAxisRaw("HorizontalP2");
                if (Input.GetAxisRaw("JumpP2") > 0.7f)
                {
                    jump();
                }
                print(Input.GetAxisRaw("JumpP2"));

                if (Input.GetButtonDown("UpperCutP2"))
                {
                    AttackType = attackType.UpperCut_;
                    attack(AttackType);
                }
                else if (Input.GetButtonDown("MediumCutP2"))
                {
                    AttackType = attackType.mediumCut_;
                    attack(AttackType);

                }
                else if (Input.GetButtonDown("LowerCutP2"))
                {
                    AttackType = attackType.Lowercut_;
                    attack(AttackType);

                }
            }
          
          
        }


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
                    enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 20), ForceMode2D.Impulse);
                    enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 2;

                    damage = uDamage;

                    break;
                case attackType.mediumCut_:
                    enemyCollider = Physics2D.OverlapCircle(mediumCut.position, attackRadius, enemyLayer);
                    enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 2;
                    if (enemyCollider.GetComponent<PlayerMovment>().isgrounded == false)
                    {

                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(2 * side, 5), ForceMode2D.Impulse);


                    }

                    damage = mDamage;
                    break;
                case attackType.Lowercut_:
                    enemyCollider = Physics2D.OverlapCircle(Lowercut.position, attackRadius, enemyLayer);
                    enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 2;

                    if (isgrounded == false)
                    {

                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 20), ForceMode2D.Impulse);


                    }


                    damage = lDamage;
                    break;
                default:
                    break;
            }
            if(enemyCollider != null)
            {
              StartCoroutine(enemyCollider.GetComponent<Health>().takeDamage(damage));

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
