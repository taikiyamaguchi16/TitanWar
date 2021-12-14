using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIBullet : MonoBehaviourPunCallbacks
{
    [SerializeField] Text now;
    [SerializeField] Text max;

    BasicItemInformation basicItemInformation;

    public void BulletManagerGetNotification()
    {
        basicItemInformation = this.transform.GetComponentInChildren<BasicItemInformation>();
    }

    private void Update()
    {
        if (basicItemInformation != null)
        {
            now.text = basicItemInformation.BulletNum.ToString();
            max.text = basicItemInformation.MaxBulletNum.ToString();
        }
        else
        {
            now.text = "0";
            max.text = "0";
        }
    }
}
