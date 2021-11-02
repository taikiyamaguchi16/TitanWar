﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    public bool isOffline = false;

    public void Connect()
    {
        if (!isOffline)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("オフラインモード");
            PhotonNetwork.OfflineMode = true;
        }
    }

    public void Disconnect()
    {
        if (!isOffline)
        {
            PhotonNetwork.Disconnect();
        }
        else
        {
            PhotonNetwork.OfflineMode = false;
        }
    }

    private void Start()
    {
        //PhotonNetwork.NickName = "Player";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        //PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
    }
}