using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("Offset", Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
