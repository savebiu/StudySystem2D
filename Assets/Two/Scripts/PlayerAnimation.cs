using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rb;

    
    void Start()
    {

    }

    void Update()
    {
        SetAnimation();
    }
    //�������
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //�����л�
    public void SetAnimation()
    {
        //��ȡ�ƶ��ٶ�
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));      //ע�⣬�����ƶ�ʱxΪ����������Ҫȡ����ֵ
    }
    
}
