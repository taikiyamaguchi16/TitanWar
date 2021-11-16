using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestPickUpItem : MonoBehaviourPunCallbacks
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Gun")
        {
            photonView.RPC(nameof(RPCPickUpItem), RpcTarget.All, photonView.ViewID, collision.gameObject.GetPhotonView().ViewID);
        }
    }

    [PunRPC]
    public void RPCPickUpItem(int _pId, int _iId)
    {

        //NetworkObjContainer.NetworkObjDictionary[_iId].transform.parent = this.transform;

        WeaponController w_c = NetworkObjContainer.NetworkObjDictionary[_pId].GetComponent<WeaponController>();

        w_c.EquipWeapon(NetworkObjContainer.NetworkObjDictionary[_iId]);
    }
}
