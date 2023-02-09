using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum playerNumber

{
    playerOne, PlayerTwo
}

public class BasePlayer : MonoBehaviour
{
    public player playerNum;

    //Stats
    public string playerName;
    public float speed;
    public float jumpForce;
    public float attackRadius;
    public int damage;
    public bool block;

    [HideInInspector] public bool attacking;
    public float stunTimer;
    public bool stuned;

    //Enemy
    public LayerMask ground, enemyLayer;
    public LayerMask P1Mask, P2Mask;
    [HideInInspector] public Collider2D enemyCollider;

    //Controller
    public Controller control;
    [HideInInspector] public Transform enemy;
    [HideInInspector] public Transform StartPos;

    //Movement
    [HideInInspector] public Vector2 movementInput;
    [HideInInspector] public float horizontal;
    [HideInInspector] public int side;

    public Transform legs;
    public bool isgrounded;


    [Header("Combo")]
    [HideInInspector] public float windowTimer = 0.3f;
    [HideInInspector] public float windowTimerCold = 0.6f;
    [HideInInspector] public int combo;
    [HideInInspector] public bool exhusted;


    //Sounds
    public AudioClip[] attackSound;
    public AudioClip[] walkSound;

    //
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Health hpScript;

    public Transform UpperCut, mediumCut, Lowercut;


    private void OnDisable()
    {
        control.Disable();
    }

    private void OnEnable()
    {
        control = new Controller();
        control.Enable();

    }

}
