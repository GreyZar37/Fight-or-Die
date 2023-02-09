using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Skel : BasePlayer

{
    public enum currentAttack
    {
        UpperCut_, mediumCut_, Lowercut_
    }

    //Controlls
    bool jumped, middleCut, upperCut, kick;


    //Combat
    public currentAttack AttackType;

    private void Awake()
    {
        //Player setup
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
        hpScript = GetComponent<Health>();
       
    }

    // Start is called before the first frame update
    void Start()
    {

    
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        CombatSystem();
        isgrounded = Physics2D.OverlapCircle(legs.transform.position, 0.1f, ground);
        anim.SetFloat("Velocity", Mathf.Abs(horizontal));

    }




    void playerMovement()
    {
        if (stuned == false)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
          
        }
        if (attacking && isgrounded == true || stuned && isgrounded == true || exhusted && isgrounded == true || GameManager.gameState != gameState.Combat)
        {
          horizontal = 0;
          rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else if(attacking && isgrounded == false)
        {
            horizontal = movementInput.x;
              
        }
    }
     
   
    public void CombatSystem()
    {
        if (attacking == false && stuned == false && exhusted == false && GameManager.gameState == gameState.Combat)
        {
            horizontal = movementInput.x;

            if (jumped)
            {
                jump();
            }

            if (upperCut)
            {
                AttackType = currentAttack.UpperCut_;
                anim.SetTrigger("UpperCut");
                StartCoroutine(Attack(AttackType, 1));


            }
            else if (middleCut)
            {
                AttackType = currentAttack.mediumCut_;
                anim.SetTrigger("MediumCut");
                StartCoroutine(Attack(AttackType, 1));

            }
            else if (kick)
            {
                anim.SetTrigger("LowerCut");

                AttackType = currentAttack.Lowercut_;
                StartCoroutine(Attack(AttackType, 1));

            }

        }
    }

    void jump()
    {
        if (isgrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }
    public void OnMiddleCut(InputAction.CallbackContext context)
    {
        middleCut = context.action.triggered;
    }

    public void OnLowerCut(InputAction.CallbackContext context)
    {
        kick = context.action.triggered;
    }

    public void OnUpperCut(InputAction.CallbackContext context)
    {
        upperCut = context.action.triggered;
    }


    IEnumerator Attack(currentAttack type, float animMultiplier)
    {
        AudioManager.instance.playSound(attackSound, 1);
        attacking = true;
        anim.speed = 1 * animMultiplier;
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length / 2);
        

        switch (type)
        {
            case currentAttack.UpperCut_:
                enemyCollider = Physics2D.OverlapCircle(UpperCut.position, attackRadius, enemyLayer);

                if (enemyCollider != null)
                {
                    enemyCollider.GetComponent<Health>().stun(0.5f);


                    enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * side, 20), ForceMode2D.Impulse);
                    enemyCollider.GetComponent<Rigidbody2D>().gravityScale += 1;

                }


                break;
            case currentAttack.mediumCut_:
                enemyCollider = Physics2D.OverlapCircle(mediumCut.position, attackRadius, enemyLayer);

                if (enemyCollider != null)
                {
                    enemyCollider.GetComponent<Health>().stun(0.5f);

                    if (enemyCollider.GetComponent<BasePlayer>().isgrounded == false)
                    {

                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * side, 15), ForceMode2D.Impulse);


                    }
                    else
                    {
                        enemyCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * side, 0), ForceMode2D.Impulse);

                    }
                }

                break;
            case currentAttack.Lowercut_:
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

                break;
     
        }


        if (enemyCollider != null)
        {

            enemyCollider.GetComponent<BasePlayer>().StopAllCoroutines();
            enemyCollider.GetComponent<BasePlayer>().attacking = false;
            enemyCollider.GetComponent<BasePlayer>().exhusted = false;
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
}
