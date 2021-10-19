using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeathBullet : MonoBehaviourPunCallbacks
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;   
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (photonView.IsMine)
        {
            if (time > 1.8f)
            {
                // 出現させたボールを0.8秒後に消す
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
