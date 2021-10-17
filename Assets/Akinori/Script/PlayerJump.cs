using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody PlayerRigid;//PlayerオブジェクトのRigidbobyを保管する
    public float Upspeed;　　　　//ジャンプのスピード

    private bool isJump;

    // Use this for initialization
    void Start()
    {
        isJump = false;
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

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;

            if (Input.GetKey(KeyCode.Space))
            {
                PlayerRigid.AddForce(transform.up * Upspeed);
                //PlayerRigid.AddForce(transform.forward * Upspeed);
            }
        }
        else
        {
            isJump = true;
        }
    }

    public bool GetIsJump()
    {
        return isJump;
    }
}
