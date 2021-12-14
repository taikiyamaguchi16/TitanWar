using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TitanGameManager : MonoBehaviourPunCallbacks
{
    private int dieCount;

    public string whichPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        dieCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PCPlayerDie()
    {
        dieCount++;
        if(dieCount>3)
        {
            photonView.RPC(nameof(RPCGameResultCheck), RpcTarget.All, "VRPlayer");
        }
    }

    public void VRPlayerDie()
    {
        dieCount++;
        photonView.RPC(nameof(RPCGameResultCheck), RpcTarget.All, "PCPlayer");
    }

    [PunRPC]
    public void RPCGameResultCheck(string _winPlayer)
    {
        if(whichPlayerName == _winPlayer)
        {
            Debug.Log("勝ちました");
        }
        else
        {
            Debug.Log("負けました");
        }
    }
}
