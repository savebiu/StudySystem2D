using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //地面检测
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
