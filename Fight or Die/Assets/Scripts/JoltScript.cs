using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoltScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int damage;
    public AudioClip[] zap;
    public AudioClip[] hit;

    bool damaged;

    bool parryed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioManager.instance.playSound(zap, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
        transform.Rotate(0, 0, -0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null)
        {
            if (collision.GetComponent<PlayerMovment>().block)
            {

                if (!parryed)
                {
                    parryed = true;

                    speed *= 2;

                }

                if (transform.rotation.y == 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                }

            }
            else if(damaged == false)
            {
                StartCoroutine(collision.GetComponent<Health>().takeDamage(damage));
                damaged = true;
                collision.GetComponent<Health>().stun(.5f);

                StartCoroutine(destroy_());
            }

   
        }
        else
        {
            if(collision.tag != "Jolt")
            {
                StartCoroutine( destroy_());
            }
        }
    }

    IEnumerator destroy_()
    {
        AudioManager.instance.playSound(hit, 1);

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }
}
