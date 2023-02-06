using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikes : MonoBehaviour
{
    Animator anim;
    bool active;

    float cooldown = 2f;
    float currentTimer;

    [SerializeField] SpriteRenderer[] spikes;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(spikeTimer(Random.Range(10, 20)));
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
    
    }

 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovment>() != null && currentTimer <= 0 && active)
        {
            anim.SetTrigger("Hit");
            StartCoroutine(collision.GetComponent<Health>().takeDamage(10));
            collision.GetComponent<Health>().stun(0.5f);
            currentTimer = cooldown;

        }
    }

    IEnumerator spikeTimer(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            print("Start");
            active = false;
            for (int i = 0; i < spikes.Length; i++)
            {
                spikes[i].color = Color.black;
            }

           

            yield return new WaitForSeconds(timer);
            anim.SetBool("GoingUp", true);

            yield return new WaitForSeconds(2);
            anim.SetBool("GoingUp", false);

            for (int i = 0; i < spikes.Length; i++)
            {
                spikes[i].color = Color.white;
            }
            active = true;
            print("end");

        }


    }
}
