using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WeaponEquip : MonoBehaviourPunCallbacks
{
    //private GameObject mainCamera;

    enum MODE
    {
        STRAY,
        OWNED,
    }

    MODE mode = MODE.STRAY;
    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mode = MODE.STRAY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && mode == MODE.STRAY)
        {
            photonView.RPC(nameof(RPCChangeOwned), RpcTarget.All, collision.gameObject.GetComponent<WeaponController>().weaponFrame.gameObject.GetPhotonView().ViewID);
        }
        //collision.gameObject.GetPhotonView().ViewID
    }

    [PunRPC]
    private void RPCChangeOwned(GameObject _player)
    {
        mode = MODE.OWNED;
        foreach (Transform child in _player.GetComponent<WeaponController>().weaponFrame.transform)
        {
            Destroy(child.gameObject);
        }
        this.transform.parent = _player.GetComponent<WeaponController>().weaponFrame.transform;

    }

    
}
