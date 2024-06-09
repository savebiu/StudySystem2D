using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //������
    public bool isGround;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRedious = 0.1f;


    private void Update()
    {
        Check();
    }
    public void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position, checkRedious, groundLayer);
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
