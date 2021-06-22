using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    private Transform charcterTransform;
    private Rigidbody charcterRigdbody;
    public float Speed;//速度
    public float Gravite;//下坠速度
    public float JumpHeight;//能跳多高
    private bool isGrounded;//是否坠地
    private void Start()
    {
        charcterTransform = transform;
        charcterRigdbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isGrounded)
        {
            var tmp_Horizontal = Input.GetAxis("Horizontal");//获取水平轴输入
            var tmp_Vertical = Input.GetAxis("Vertical");//获取垂直轴输入

            var tmp_CurrentDirection = new Vector3(tmp_Horizontal, 0, tmp_Vertical);//封装
            tmp_CurrentDirection = charcterTransform.TransformDirection(tmp_CurrentDirection);
            tmp_CurrentDirection *= Speed;

            var tmp_CurrentVelocity = charcterRigdbody.velocity;
            var tmp_VelocityChange = tmp_CurrentDirection - tmp_CurrentVelocity;
            tmp_VelocityChange.y = 0;

            charcterRigdbody.AddForce(tmp_VelocityChange, ForceMode.VelocityChange);

            if (Input.GetButtonDown("Jump"))
            {
                charcterRigdbody.velocity = new Vector3(tmp_CurrentVelocity.x, CalculateJumpHeightSpeed(), tmp_CurrentVelocity.z);
            }
        }
        charcterRigdbody.AddForce(new Vector3(0, -Gravite*charcterRigdbody.mass, 0));
    }

    private float CalculateJumpHeightSpeed()
    {
        return Mathf.Sqrt(2 * Gravite * JumpHeight);
    }

    private void OnCollisionStay(Collision _other)//如果物体触碰地面就返回true
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision _other)//如果物体离开地面就返回false
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
