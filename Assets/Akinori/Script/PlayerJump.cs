using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerJump : MonoBehaviourPunCallbacks
{

    public enum JUMPSTATE{
        NOTJUMP,
        FIRSTJUMP,
        JETJUMP,
        DESCENT
    }

    

    public Rigidbody rb;

    public float JumpPower;
    public float JetJumpTime;
    private float initJetJumpTime;
    public JUMPSTATE jumpState;
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
        jumpState = JUMPSTATE.NOTJUMP;
        initJetJumpTime = JetJumpTime;
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (OnGround)
            {
                JetJumpTime = initJetJumpTime;
                jumpState = JUMPSTATE.NOTJUMP;
                jetJumpEnable = false;
            }
            else
            {

                //�X�y�[�X��b���������̓W�F�b�g�^�C�����O�ɂȂ����Ƃ�
                if (Input.GetKeyUp(KeyCode.Space) && jumpState == JUMPSTATE.JETJUMP || JetJumpTime <= 0)
                {
                    jumpState = JUMPSTATE.DESCENT;
                    jetJumpEnable = false;
                }
            }
            if ( jumpState == JUMPSTATE.FIRSTJUMP && Input.GetKeyUp(KeyCode.Space))
            {
                jetJumpEnable = true;

                Debug.Log(jetJumpEnable);
            }

            if (Input.GetKey(KeyCode.Space) && jetJumpEnable && jumpState == JUMPSTATE.FIRSTJUMP )
            {
                jumpState = JUMPSTATE.JETJUMP;
                
            }
            if (jumpState == JUMPSTATE.JETJUMP)
            {
                JetJumpTime -= Time.deltaTime;
            }
        }
    }

    //Rigitbody�������邽��FixedUpdate�ŏ������s��
    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            //�ڒn���Ă���΃W�����v�ł���
            if (Input.GetKey(KeyCode.Space) && OnGround)//�ǋL
            {
                Debug.Log("Jump");
                //  rb.velocity = transform.up * JumpPower;
                rb.AddForce(transform.up * JumpPower);
                //�W�����v�����u�Ԑڒn���������
                OnGround = false;
                jumpState = JUMPSTATE.FIRSTJUMP;
                isJetJumped = false;
            }

            if (jumpState == JUMPSTATE.JETJUMP)
            {
                rb.AddForce(transform.up * (JumpPower * 0.1f));
            }
            if (jumpState == JUMPSTATE.DESCENT)
            {
                //rb.velocity = new Vector3(rb.velocity.x, -15, rb.velocity.z);
            }
        }
    }   
}
