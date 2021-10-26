using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RevolverGun : MonoBehaviourPunCallbacks, IPlayerAction
{
    [SerializeField]
    private BasicItemInformation parameter;

    [Header("各アイテムの独自パラメータ")]
    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (photonView.IsMine)
                InPlayerAction();
        }
    }

    public void InPlayerAction()
    {
        parameter.ElapsedTime += Time.deltaTime;
        if (parameter.RateTime < parameter.ElapsedTime)
        {
            photonView.RPC(nameof(Shot), RpcTarget.All);
        }

    }

    public void EndPlayerAction()
    {

    }

    [PunRPC]
    private void Shot()
    {
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = PhotonNetwork.Instantiate(bullet.name, transform.GetChild(0).transform.position, transform.rotation);
        newBall.transform.parent = this.transform;
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = newBall.transform.forward;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * parameter.Speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;

        parameter.ElapsedTime = 0f;
    }
}
