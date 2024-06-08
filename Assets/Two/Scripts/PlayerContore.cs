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

    [Header("��������")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public int jumpCount = 1;
    //������
    public bool isGround;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRedious = 0.1f;

    //public ParticleSystem jumpEffect; ����ϵͳ
    //public AudioSource jumpSound; ����
   
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        //��ת
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
    //��ת
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
        //����Ƿ����
        
        if (isGround)
        {
            jumpCount = 1;
        }

        
    }
    //���Ȧ
    private void OnDrawGizmos()
    {
        /*if (groundCheck == null)
        {
            return;
        }*/
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, checkRedious);  // �������λ�û���һ���뾶Ϊ1�Ŀ�������
    }

}
