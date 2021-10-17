﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DestroyMainCamera : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            Destroy(Camera.main.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
