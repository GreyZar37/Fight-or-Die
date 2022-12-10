using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Slider stamina;

    int maxHp = 100;
    int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;

        healthBar.maxValue = maxHp;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHp;
        
    }

    public void takeDamage(int damage)
    {
        currentHp -= damage;
    }
}
