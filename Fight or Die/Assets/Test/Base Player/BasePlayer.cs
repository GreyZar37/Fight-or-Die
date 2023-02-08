using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum playerNumber

{
    playerOne, PlayerTwo
}

public class BasePlayer : MonoBehaviour
{
    public string playerName;
    public float speed;
    public float jumpForce;
    public float attackRadius;

    bool attacking;
    public float stunTimer;
    public bool stuned;
    int side;


    public LayerMask ground, enemyLayer;
    public LayerMask P1Mask, P2Mask;

    [SerializeField] Transform legs;
    public bool isgrounded;

    Animator anim;

    [SerializeField] Health hpScript;
    public Transform StartPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
