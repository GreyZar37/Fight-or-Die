using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] PlayerMovment playermov;

    [SerializeField] Slider healthBar;
    [SerializeField] Slider stamina;

    [SerializeField] Material originalMaterial, hitMaterial;
    [SerializeField] SpriteRenderer spriteRend;

    [SerializeField] GameManager gameMan;

    Animator anim;

    int maxHp = 100;
    public int currentHp;

    int maxStamina = 100;
    public int currentStamina;

    // Start is called before the first frame update
    void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        originalMaterial = spriteRend.material;
        currentHp = maxHp;

        healthBar.maxValue = maxHp;
        stamina.maxValue = maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHp;
        stamina.value = currentStamina;

    }


    public IEnumerator takeDamage(int damage)
    {
        anim.SetTrigger("Hit");
        playermov.stuned = true;
        currentHp -= damage;
        currentStamina += damage * 2;
      
         if (currentHp <= 0 && GameManager.gameState == gameState.Combat)
        {
            StartCoroutine(gameMan.endGame(playermov.playerNum));
            GameManager.gameState = gameState.ending;
        }

        spriteRend.material = hitMaterial;

        yield return new WaitForSeconds(0.1f);
        spriteRend.material = originalMaterial;

        yield return new WaitForSeconds(0.2f);
       
            playermov.stuned = false;
        
       

    }
}
