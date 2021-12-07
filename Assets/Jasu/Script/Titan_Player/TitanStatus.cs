using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TitanStatus : SliderValue
{
    [SerializeField]
    float hpMax = 100f;

    [SerializeField]
    float hp = 0;

    [SerializeField]
    float mpMax = 100f;

    [SerializeField]
    float mp = 0;

    [SerializeField]
    MaterialBlink materialBlink;

    // Start is called before the first frame update
    void Start()
    {
        sliderMaxValue = hpMax;
        hp = hpMax;
        mp = mpMax;
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerAttack")
        {
            if (other.gameObject.GetComponent<AttackManager>() != null)
            {
                hp -= other.gameObject.GetComponent<AttackManager>().AttackPower;
            }
            else
            {
                photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            if (collision.gameObject.GetComponent<AttackManager>() != null)
            {
                hp -= collision.gameObject.GetComponent<AttackManager>().AttackPower;
            }
            else
            {
                photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            }
            
            materialBlink.BlinkStart();
        }
    }

    [PunRPC]
    public void RPCDamage()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            hp -= 10;
        }
    }
}
