using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxManager : MonoBehaviour
{
    [Header("生成間隔(秒数)")]
    [SerializeField] private int m_interval = 30;

    //開始何秒まではレアアイテムを出さないようにする
    private int NonrareSeconds = 30;
    private bool timeOverNonrare = true;



    [Header("アイテムボックス")]
    [SerializeField]
    private ItemBox[] m_objItembox;

    [Header("アイテムボックス(数)")]
    [SerializeField]
    private int m_MaxNum=0;

    float m_myTime;//経過時間


    //確率確認用
    float compRate;

    [Header("それぞれの確率(上からレア度が低い)")]
    public float[] popRate = new float[3];
    private float[] saveRate = new float[3];    //保存用Rate
    private float popNum;


    


    // Start is called before the first frame update
    void Start()
    {
        m_MaxNum = m_objItembox.Length; //アイテムボックスの最大数を確定
        AverageRate(); //確率を綺麗にする。

        for (int i = 0; i < popRate.Length; i++)
        {
            saveRate[i] = popRate[i];   //保存する。
        }

    }

    // Update is called once per frame
    void Update()
    {
        m_myTime += Time.deltaTime;//時間を経過させる
        int second = (int)m_myTime % 60;


        if (second > NonrareSeconds && timeOverNonrare)//指定の時間を過ぎたらレアアイテム出現可能にする
        {
            timeOverNonrare = false;
            popRate[2] = saveRate[2];
            AverageRate();
        }








    }

    ////確率を綺麗にする。
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

    ////出現させるレア度を確定させる
    //Item.ITEMRATE RareDecision()
    //{

    //    float cnt = Random.Range(0f, popNum);
    //    for (int i = 0; i < popRate.Length; i++)
    //    {
    //        if (popRate[i] < cnt)//比較する
    //        {
    //            cnt -= popRate[i];
    //        }
    //        else
    //        {
    //            return (Item.ITEMRATE)i;//レア度を確定させる
    //        }
    //    }

    //    Debug.Log("通ってはいけないルート:ItemBoxManager");
    //    return Item.ITEMRATE.NORMAL;
    //}



}
