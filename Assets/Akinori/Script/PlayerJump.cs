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

    //追記
    private void Start()
    {
        OnGround = false;
    }

    //RigitbodyをいじるためFixedUpdateで処理を行う
    private void FixedUpdate()
    {
        //接地していればジャンプできる
        if (Input.GetKey(KeyCode.Space) && OnGround)//追記
        {
            Debug.Log("Jump");
            rb.velocity = transform.up * JumpPower;
          //  rb.AddForce(transform.up * JumpPower);
            //ジャンプした瞬間接地判定を解除
            OnGround = false;//追記
        }
    }



    //public GameObject Player;
    //private Rigidbody PlayerRigid;//PlayerオブジェクトのRigidbobyを保管する
    //public float Upspeed;　　　　//ジャンプのスピード

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
    //    //    //上にジャンプする。
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
