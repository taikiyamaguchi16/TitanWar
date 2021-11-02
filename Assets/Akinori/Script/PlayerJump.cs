using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerJump : MonoBehaviourPunCallbacks
{
    public GameObject Player;
    private Rigidbody PlayerRigid;//PlayerオブジェクトのRigidbobyを保管する
    public float Upspeed;　　　　//ジャンプのスピード

    private bool isJumping;

    // Use this for initialization
    void Start()
    {
        isJumping = false;
        PlayerRigid = Player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //上にジャンプする。
        //    PlayerRigid.AddForce(transform.up * Upspeed);



        //}
        if (isJumping)
        {
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    PlayerRigid.AddForce(transform.up * (Upspeed * 0.01f));
            //    PlayerRigid.AddForce(transform.forward * (Upspeed * 0.01f));
            //}
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (photonView.IsMine)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isJumping = false;


                if (Input.GetKey(KeyCode.Space))
                {
                    isJumping = true;
                    PlayerRigid.AddForce(transform.up * Upspeed);
                    //PlayerRigid.AddForce(transform.forward * Upspeed);
                    if (Input.GetKey(KeyCode.W))
                    {
                        PlayerRigid.AddForce(transform.forward * Upspeed);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        PlayerRigid.AddForce(-transform.forward * (Upspeed / 2));
                    }
                }

            }
            //else
            //{
            //    isJumping = true;
            //}
        }
    }

    public bool GetIsJump()
    {
        return isJumping;
    }
}
