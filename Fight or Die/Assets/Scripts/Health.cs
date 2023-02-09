using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{

    [SerializeField] BasePlayer PlayerScript;
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
    [SerializeField] AudioClip[] hitSound;
    float stunCurrentTimer;
    [SerializeField] GameObject DeathSkeleton;

    [SerializeField] GameObject CharacterModel;

    // Start is called before the first frame update
    void Start()
    {
        

        gameMan = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        originalMaterial = spriteRend.material;




        if (PlayerScript.playerNum == player.playerOne){
            nameText = GameObject.FindGameObjectWithTag("TextP1").GetComponent<TextMeshProUGUI>();
            healthBar = GameObject.FindGameObjectWithTag("HealthP1").GetComponent<Slider>();
            stamina = GameObject.FindGameObjectWithTag("StaminaP1").GetComponent<Slider>();

        }
        else if (PlayerScript.playerNum == player.PlayerTwo)
        {
            nameText = GameObject.FindGameObjectWithTag("TextP2").GetComponent<TextMeshProUGUI>();

            healthBar = GameObject.FindGameObjectWithTag("HealthP2").GetComponent<Slider>();
            stamina = GameObject.FindGameObjectWithTag("StaminaP2").GetComponent<Slider>();
        }
         nameText.text = GetComponent<BasePlayer>().playerName;

         currentHp = maxHp;

        healthBar.maxValue = maxHp;
        stamina.maxValue = maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina > 100)
        {
            currentStamina = 100;
        }


        if (stunCurrentTimer > 0)
        {
            stunCurrentTimer -= Time.deltaTime;
        }
        else
        {
            PlayerScript.stuned = false;
            PlayerScript.stuned = false;
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

        if (PlayerScript.block == true)
        {
            PlayerScript.stuned = false;
            currentHp -= damage / 2;
        }
        else
        {
            PlayerScript.stuned = true;
            currentHp -= damage;
            currentStamina += damage * 2;
            blood.Play();
            anim.SetTrigger("Hit");
            anim.SetBool("Stunned", true);
            AudioManager.instance.playSound(damagedSound, 1);
            AudioManager.instance.playSound(hitSound, 1);


        }


        ShakeScreen.isShaking = true;


        
       
      
         if (currentHp <= 0 && GameManager.gameState == gameState.Combat)
        {
            StartCoroutine(gameMan.endGame(PlayerScript.playerNum));
            Instantiate(DeathSkeleton, PlayerScript.gameObject.transform);
            CharacterModel.SetActive(false);
            GameManager.gameState = gameState.ending;
        }

        spriteRend.material = hitMaterial;

        yield return new WaitForSeconds(0.1f);
        spriteRend.material = originalMaterial;

       
        


    }
}
