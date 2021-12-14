using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class ChoicePlayer : MonoBehaviourPunCallbacks
{
    //各デバイス選択時の生成するオブジェクト
    public GameObject vr_player;
    public GameObject pc_player;
    //遷移するシーンの名前
    public string sceneName;
    //最終的に生成するオブジェクト
    private GameObject spownPlayer;
    //ロビー接続時にアクティブにするため
    public GameObject choicebutton;

    [SerializeField]
    TitanGameManager titanGameManager;
    // Start is called before the first frame update

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    public void ChoiceVR()
    {
        spownPlayer = vr_player;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = PhotonNetwork.Instantiate(spownPlayer.name, Vector3.zero, transform.rotation);
        choicebutton.SetActive(false);

        titanGameManager.whichPlayerName = "VRPlayer";
    }

    public void ChoicePC()
    {
        spownPlayer = pc_player;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = PhotonNetwork.Instantiate(spownPlayer.name, Vector3.zero, transform.rotation);
        choicebutton.SetActive(false);

        titanGameManager.whichPlayerName = "PCPlayer";
    }

    public override void OnJoinedRoom()
    {
        choicebutton.SetActive(true);
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        //Debug.Log(nextScene.name);
    }
}
