using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DestroyMainOrOther : MonoBehaviourPunCallbacks
{
    [SerializeField]
    bool isMain = false;

    private void Awake()
    {
        if ((!photonView.IsMine && isMain) || (photonView.IsMine && !isMain))
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
