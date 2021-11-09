using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerJump : MonoBehaviourPunCallbacks
{
    public Rigidbody rb;
    public float JumpPower;
    //�ڒn����
    public bool OnGround { get; set; }//�ǋL

    private bool isJetJumped { get; set; }
    private bool jetJumpEnable { get; set; }
    //�ǋL
    private void Start()
    {
        OnGround = false;
        isJetJumped = false;
        jetJumpEnable = false;
    }

    //Rigitbody�������邽��FixedUpdate�ŏ������s��
    private void FixedUpdate()
    {
        //�ڒn���Ă���΃W�����v�ł���
        if (Input.GetKey(KeyCode.Space) && OnGround)//�ǋL
        {
            Debug.Log("Jump");
            //  rb.velocity = transform.up * JumpPower;
            rb.AddForce(transform.up * JumpPower);
            //�W�����v�����u�Ԑڒn���������
            OnGround = false;
            isJetJumped = false;
        }
        
    }   
}
