using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBase : MonoBehaviour {
    [Header("確認用パラメーター")]
    [SerializeField, ReadOnly]
    [Tooltip("一発当たりの発射時間")]
    protected float rateTime;

    [SerializeField, ReadOnly]
    [Tooltip("一秒あたりのダメージ")]
    protected float dps;
    [Space(10)]

    [SerializeField]
    [Tooltip("弾数")]
    protected int bulletNum;

    [SerializeField]
    [Tooltip("ワンマガジンのサイズ")]
    protected int magazineSize;

    [SerializeField]
    [Tooltip("リロードの時間")]
    protected int reloadTime;

    [SerializeField]
    [Tooltip("1秒あたりの発射数")]
    protected float rate;

    [SerializeField]
    [Tooltip("1発あたりのダメージ")]
    protected float damage;

    [SerializeField]
    [Tooltip("弾の速さ")]
    protected float speed;

    [SerializeField]
    [Tooltip("ヘッドショット倍率")]
    protected float headMagnification;

    //経過時間
    protected float elapsedTime;

   


    private void Start()
    {
     
    }
    //弾切れの処理
    public void OutOfAmmo()
    {
        
    }
    public virtual void InPlayerAction()
    {
        
    }

    public virtual void EndPlayerAction()
    {
        
    }
    //インスペクターの値の変更時に呼び出される関数
    protected virtual void OnValidate()
    {
        rateTime = 1f / rate;

        dps = damage * rate;
    }
}
