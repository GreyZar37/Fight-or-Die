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

    int maxHp = 100;
    int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = spriteRend.material;
        currentHp = maxHp;

        healthBar.maxValue = maxHp;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHp;
        
    }

  
    public IEnumerator takeDamage(int damage)
    {
        playermov.stuned = true;
        currentHp -= damage;
        spriteRend.material = hitMaterial;

        yield return new WaitForSeconds(0.1f);
        spriteRend.material = originalMaterial;

        yield return new WaitForSeconds(0.2f);
       
            playermov.stuned = false;
        


    }
}
