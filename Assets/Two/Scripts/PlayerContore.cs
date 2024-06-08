using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class PlayerContore : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 flippedScale = new Vector3(-1, 1, 1);
    float moveX;
    float moveY;

    [Header("基本参数")]
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private int jumpCount = 1;
    private bool isGround;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRedious = 0.1f;
    //public ParticleSystem jumpEffect; 粒子系统
    //public AudioSource jumpSound; 声音

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        Derection();
        Movement();
        Jumping();
    }
    private void Derection()
    {

        if (moveX < 0)
        {
            transform.localScale = flippedScale;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    private void Movement()
    {

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveSpeed*moveX, rb.velocity.y);

    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRedious, groundLayer);
        if(isGround)
        {
            jumpCount = 0;
        }
    }
}
