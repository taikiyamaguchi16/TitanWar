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

    //�ǋL
    private void Start()
    {
        OnGround = false;
    }

    //Rigitbody�������邽��FixedUpdate�ŏ������s��
    private void FixedUpdate()
    {
        //�ڒn���Ă���΃W�����v�ł���
        if (Input.GetKey(KeyCode.Space) && OnGround)//�ǋL
        {
            Debug.Log("Jump");
            rb.velocity = transform.up * JumpPower;
          //  rb.AddForce(transform.up * JumpPower);
            //�W�����v�����u�Ԑڒn���������
            OnGround = false;//�ǋL
        }
    }



    //public GameObject Player;
    //private Rigidbody PlayerRigid;//Player�I�u�W�F�N�g��Rigidboby��ۊǂ���
    //public float Upspeed;�@�@�@�@//�W�����v�̃X�s�[�h

    //private bool isJump;

    //// Use this for initialization
    //void Start()
    //{
    //    isJump = false;
    //    Player = this.gameObject;
    //    PlayerRigid = Player.GetComponent<Rigidbody>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Space))
    //    //{
    //    //    //��ɃW�����v����B
    //    //    PlayerRigid.AddForce(transform.up * Upspeed);



    //    //}

    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (photonView.IsMine)
    //    {
    //        if (collision.gameObject.tag == "Ground")
    //        {
    //            isJump = false;


    //            if (Input.GetKey(KeyCode.Space))
    //            {
    //                PlayerRigid.AddForce(transform.up * Upspeed);
    //                //this.transform.position += (this.transform.up * Time.deltaTime);
    //                //PlayerRigid.AddForce(transform.forward * Upspeed);
    //            }

    //        }
    //        else
    //        {
    //            isJump = true;
    //        }
    //    }
    //}

    //public bool GetIsJump()
    //{
    //    return isJump;
    //}
}
