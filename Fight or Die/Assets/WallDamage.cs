using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{
    Animator anim;
    bool instakill;
    public bool move;
    Rigidbody2D rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move == true)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = true;

            rb.velocity = transform.right* speed;
            instakill = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Trapped");

        if(instakill == true)
        {
            StartCoroutine(collision.GetComponent<Health>().takeDamage(100, .4f));
            move = false;

        }
        else
        {
            StartCoroutine(collision.GetComponent<Health>().takeDamage(20, .4f));

        }
    }
}
