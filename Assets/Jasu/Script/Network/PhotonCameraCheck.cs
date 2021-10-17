using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonCameraCheck : MonoBehaviourPunCallbacks
{ 
    [SerializeField]
    List<Camera> cameraList = new List<Camera>();

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            foreach(var camera in cameraList)
            {
                camera.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
