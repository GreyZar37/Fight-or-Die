using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{

    [SerializeField] PlayerMovment playermov;
    TextMeshProUGUI nameText;

   Slider healthBar;
   Slider stamina;

    [SerializeField] Material originalMaterial, hitMaterial;
    [SerializeField] SpriteRenderer spriteRend;

    [SerializeField] GameManager gameMan;
    [SerializeField] ParticleSystem blood;
    Animator anim;

    int maxHp = 100;
    public int currentHp;

    int maxStamina = 100;
    public int currentStamina;

    [SerializeField] AudioClip[] damagedSound;
    float stunCurrentTimer;


    // Start is called before the first frame update
    void Start()
    {


        gameMan = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        originalMaterial = spriteRend.material;




        if (playermov.playerNum == player.playerOne){
            nameText = GameObject.FindGameObjectWithTag("TextP1").GetComponent<TextMeshProUGUI>();
            healthBar = GameObject.FindGameObjectWithTag("HealthP1").GetComponent<Slider>();
            stamina = GameObject.FindGameObjectWithTag("StaminaP1").GetComponent<Slider>();

        }
        else if (playermov.playerNum == player.PlayerTwo)
        {
            nameText = GameObject.FindGameObjectWithTag("TextP2").GetComponent<TextMeshProUGUI>();

            healthBar = GameObject.FindGameObjectWithTag("HealthP2").GetComponent<Slider>();
            stamina = GameObject.FindGameObjectWithTag("StaminaP2").GetComponent<Slider>();
        }
         nameText.text = GetComponent<PlayerMovment>().playerName;

         currentHp = maxHp;

        healthBar.maxValue = maxHp;
        stamina.maxValue = maxStamina;

    }

    // Update is called once per frame
    void Update()
    {

        if(stunCurrentTimer > 0)
        {
            stunCurrentTimer -= Time.deltaTime;
        }
        else
        {
            playermov.stuned = false;
            playermov.stuned = false;
            anim.SetBool("Stunned", false);

        }

        healthBar.value = currentHp;
        stamina.value = currentStamina;

    }

    public void stun(float stunTimer)
    {
        stunCurrentTimer = stunTimer;


    }

    public IEnumerator takeDamage(int damage)
    {


        anim.SetTrigger("Hit");
        anim.SetBool("Stunned", true);

        AudioManager.instance.playSound(damagedSound, 1);
        ShakeScreen.isShaking = true;
        blood.Play();


        if(playermov.block == true)
        {
            playermov.stuned = false;
            currentHp -= damage/2;
        }
        else
        {
            playermov.stuned = true;
            currentHp -= damage;
            currentStamina += damage * 2;
        }
       
      
         if (currentHp <= 0 && GameManager.gameState == gameState.Combat)
        {
            StartCoroutine(gameMan.endGame(playermov.playerNum));
            GameManager.gameState = gameState.ending;
        }
         if (playermov.stuned == false)
        {
        }
        spriteRend.material = hitMaterial;

        yield return new WaitForSeconds(0.1f);
       
        spriteRend.material = originalMaterial;

       
        


    }
}
