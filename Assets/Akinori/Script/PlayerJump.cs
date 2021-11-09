using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerJump : MonoBehaviourPunCallbacks
{
    public Rigidbody rb;
    public float JumpPower;
    //接地判定
    public bool OnGround { get; set; }//追記

    private bool isJetJumped { get; set; }
    private bool jetJumpEnable { get; set; }
    //追記
    private void Start()
    {
        OnGround = false;
        isJetJumped = false;
        jetJumpEnable = false;
    }

    //RigitbodyをいじるためFixedUpdateで処理を行う
    private void FixedUpdate()
    {
        //接地していればジャンプできる
        if (Input.GetKey(KeyCode.Space) && OnGround)//追記
        {
            Debug.Log("Jump");
            //  rb.velocity = transform.up * JumpPower;
            rb.AddForce(transform.up * JumpPower);
            //ジャンプした瞬間接地判定を解除
            OnGround = false;
            isJetJumped = false;
        }
        
    }   
}
