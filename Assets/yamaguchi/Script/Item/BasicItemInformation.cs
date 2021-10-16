using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAction
{
    void InPlayerAction();

    void EndPlayerAction();
}
public class BasicItemInformation : MonoBehaviour
{
    [Header("確認用パラメーター")]
    [SerializeField, ReadOnly]
    [Tooltip("一発当たりの発射時間")]
    private float rateTime;
    public float RateTime
    {
        get => rateTime;
        set => rateTime = value;
    }

    [SerializeField, ReadOnly]
    [Tooltip("一秒あたりのダメージ")]
    private float dps;

    [SerializeField, ReadOnly]
    private float elapsedTime;
    public float ElapsedTime
    {
        get => elapsedTime;
        set => elapsedTime = value;
    }
    [Space(10)]

    [SerializeField]
    [Tooltip("弾数")]
    private int bulletNum;
    public int BulletNum
    {
        get => bulletNum;
        set => bulletNum = value;
    }

    [SerializeField]
    [Tooltip("ワンマガジンのサイズ")]
    private int magazineSize;
    public int MagazineSize
    {
        get => magazineSize;
        set => magazineSize = value;
    }


    [SerializeField]
    [Tooltip("リロードの時間")]
    private float reloadTime;
    public float ReloadTime
    {
        get => reloadTime;
        set => reloadTime = value;
    }
    [SerializeField]
    [Tooltip("1秒あたりの発射数")]
    private float rate;
    public float Rate
    {
        get => rate;
        set => rate = value;
    }
    [SerializeField]
    [Tooltip("1発あたりのダメージ")]
    private float damage;
    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    [SerializeField]
    [Tooltip("ヘッドショット倍率")]
    private float headMagnification;
    public float HeadMagnification
    {
        get => headMagnification;
        set => headMagnification = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //インスペクターの値の変更時に呼び出される関数
    protected virtual void OnValidate()
    {
        rateTime = 1f / rate;

        dps = damage * rate;
    }
}
