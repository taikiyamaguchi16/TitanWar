using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBase : MonoBehaviour{
    //アイテムごとの球数
    public int bulletNum;
    //弾の発射レート
    public float rate;
    //経過時間
    protected float elapsedTime;
    [SerializeField]
    [Tooltip("弾の速さ")]
    protected float speed;
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
}
