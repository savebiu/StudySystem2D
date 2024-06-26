using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    void Start()
    {

    }

    void Update()
    {
        SetAnimation();
        
    }
    //导入组件
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
    }

    //动画切换
    public void SetAnimation()
    {
        //同步数值给velocity.x .y
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));      //注意，朝左移动时x为负数，所以要取绝对值
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("isGround", physicsCheck.isGround);
    }
    
}
