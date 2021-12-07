using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//
#if UNITY_EDITOR
using UnityEditor;      //!< デプロイ時にEditorスクリプトが入るとエラーになるので UNITY_EDITOR で括ってね！
#endif

public class ItemBox : MonoBehaviour
{
    [Header("オンラインならチェックを入れる")]
    [SerializeField]
    private bool isOnline = false;


    [Header("生成間隔(秒数)")]
    [SerializeField] private int m_interval = 30;


    float m_time = 0f;//時間を記録する小数も入る変数.
    private bool m_isRespown = true;    //生成出来るか？（生成出来ない：false ｜生成出来る：true）

    //
    public GameObject respawnItem = null;

    private float framecount=0;


    private bool m_isHitOther = false;
    //ゆくゆくはレア度ごとに配列オブジェクトを分ける。
    [SerializeField] private GameObject[] m_objItem;

    [SerializeField]
    private int index;


    [Header("それぞれの確率(上からレア度が低い)")]
    public float[] popRate = new float[3];
    private float popNum;

    [Header("レア度：ノーマル")]
    public GameObject[] normalItem;
    private string[] normalPass= { "Item/machinegun", "Item/missile", "Item/tama" };

    [Header("レア度：レア")]
    public GameObject[] rareItem;
    private string[] rarePass = { "Item/rare_machinegun", "Item/rare_missile"};

    [Header("レア度：スーパーレア")]
    public GameObject[] superItem;
    private string[] superPass = { "Item/sr_machinegun", "Item/sr_missile" };
    // Start is called before the first frame update
    void Start()
    {
        AverageRate(); //確率を綺麗にする。
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        if (m_isRespown && !m_isHitOther)
        {
            int second = (int)m_time % 60;//秒.timeを60で割った余り.

            if (m_interval < second)
            {
                m_time = 0f;//タイムリセット

                //アイテム生成
                //PhotonView.RPC("CreateItem" , 実行させる対象のPhotonPlayer [, 引数1 , 引数2 ...] );
                CreateItem();
                m_isRespown = false;
                framecount = 0;
            }
        }

        if (respawnItem != null)
        {
            if (respawnItem.transform.parent)//アイテムの所有者がplayerになったら次のアイテムの生成開始
            {
                this.RespownReset();
            }
        }
        //if (!m_isRespown)
        //{
        //    if (respawnItem == null)
        //    {
        //        this.RespownReset();
        //    }
        //}
    }

    private void RespownReset() {
        respawnItem = null;
        m_isRespown = true;
        m_time = 0;
    }

    //インデックスを設定
    public void SetIndex(int idx)
    {
        index = idx;
    }


    // [PunRPC]//アイテムランダム生成
    private void RandomCreateItem()
    {
        int idx = Random.Range(0, m_objItem.Length);
        //Instantiate(m_objItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        GameObject obj = (GameObject)Instantiate(m_objItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = transform;
    }
    //=====================================================================
    //アイテムを生成(レア度の重みに分けて生成スタート)
    //=====================================================================
    private void CreateItem()
    {
        //レア度を確定させてアイテムをランダム生成
        RarityChoiceItem(RareDecision());
    }

    //==================================================
    //レア度が同じアイテムの中からランダムで決める。
    //==================================================
    private void RarityChoiceItem(Item.ITEMRATE itemrate)
    {
        //GameObject obj;
        int idx = 0;
        switch (itemrate)
        {
            case Item.ITEMRATE.NORMAL:
                //ランダム
                idx = Random.Range(0, normalItem.Length);
                if (isOnline)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        respawnItem = (GameObject)PhotonNetwork.InstantiateRoomObject("Item/"+normalItem[idx].name, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                        //respawnItem.transform.parent = transform;
                    }
                }
                else
                {
                    respawnItem = (GameObject)Instantiate(normalItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    //respawnItem.transform.parent = transform;
                }
                Debug.Log("NORMAL");
                break;
            case Item.ITEMRATE.RARE:
                idx = Random.Range(0, rareItem.Length);
                if (isOnline)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        respawnItem = (GameObject)PhotonNetwork.InstantiateRoomObject("Item/" + rareItem[idx].name, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                        //respawnItem.transform.parent = transform;
                    }
                }
                else
                {
                    respawnItem = (GameObject)Instantiate(rareItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    //respawnItem.transform.parent = transform;
                }
                Debug.Log("RARE");
                break;
            case Item.ITEMRATE.SR:
                idx = Random.Range(0, superItem.Length);
                if (isOnline)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        respawnItem = (GameObject)PhotonNetwork.InstantiateRoomObject("Item/" + superItem[idx].name, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                        //respawnItem.transform.parent = transform;
                    }
                }
                else
                {
                    respawnItem = (GameObject)Instantiate(superItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    //obj.transform.parent = transform;
                }
                Debug.Log("SR");
                break;
            default:
                break;
        }
    }
    //確率を綺麗にする。
    private void AverageRate()
    {
        for (int i = 0; i < popRate.Length; i++)
        {
            popNum += popRate[i];
        }
        for (int i = 0; i < popRate.Length; i++)
        {
            popRate[i] = (popRate[i] / popNum) * 100;
        }

        Debug.Log(popRate[0]);
        Debug.Log(popRate[1]);
        Debug.Log(popRate[2]);
    }

    //出現させるレア度を確定させる
    Item.ITEMRATE RareDecision()
    {

        float cnt = Random.Range(0f, popNum);
        for (int i = 0; i < popRate.Length; i++)
        {
            if (popRate[i] < cnt)//比較する
            {
                cnt -= popRate[i];
            }
            else
            {
                return (Item.ITEMRATE)i;//レア度を確定させる
            }
        }

        Debug.Log("通ってはいけないルート:ItemBoxManager");
        return Item.ITEMRATE.NORMAL;
    }





    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            m_isHitOther = true;
            Debug.Log("プレイヤー以外の何かに当たっている");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            Debug.Log("プレイヤー以外の何かが離れた");
            m_isHitOther = false;
        }
    }

}
