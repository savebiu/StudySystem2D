using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;


public class PlayerContore : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool facingRight = true;
    
    float moveX;
    float moveY;

    [Header("基本参数")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public int jumpCount = 1;
    //地面检测
    public bool isGround;

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
        //翻转
        if (moveX > 0 && !facingRight)
        {
            Derection();
        }
        if (moveX < 0 && facingRight)
        {
            Derection();
        }

        Movement();
        isGround = Physics2D.OverlapCircle((Vector2)transform.position, checkRedious, groundLayer);
        Jumping();

    }
    //翻转
    private void Derection()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

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
        //检测是否落地
        
        if (isGround)
        {
            jumpCount = 1;
        }

        
    }
    //检测圈
    private void OnDrawGizmos()
    {
        /*if (groundCheck == null)
        {
            return;
        }*/
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, checkRedious);  // 在物体的位置绘制一个半径为1的空心球体
    }

}
