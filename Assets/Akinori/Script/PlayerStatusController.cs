using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerStatusController : CharacterStatus
{
    
    public float ultPower;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        ultPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //PhotonNetwork.LocalPlayer
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TitanAttack")
        {
            TakeDamage(1);
        }
    }
}
