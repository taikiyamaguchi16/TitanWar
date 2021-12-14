using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class SliderCtrlToName : Serialize.KeyAndValue<string, SliderCtrl>
{
    public SliderCtrlToName(string key, SliderCtrl value) : base(key, value) { }
}


[System.Serializable]
public class SliderCtrlToNameTable : Serialize.TableBase<string, SliderCtrl, SliderCtrlToName> { }

public class TitanStatus : MonoBehaviourPunCallbacks
{
    [SerializeField]
    SliderCtrlToNameTable uiSliderTable;

    Dictionary<string, SliderCtrl> uiSliderDic = new Dictionary<string, SliderCtrl>();

    [SerializeField]
    float hpMax = 100f;

    [SerializeField]
    public float hp { get; private set; } = 0;

    public void DecreaseHp(float _val)
    {
        hp -= _val;
        if(hp < 0)
        {
            hp = 0f;
        }

        if (photonView.IsMine)
        {
            uiSliderDic["HP"].slider.value = hp;
        }
        else
        {
            uiSliderDic["HPforOther"].slider.value = hp;
        }
    }

    [SerializeField]
    float mpMax = 100f;

    [SerializeField]
    public float mp { get; private set; } = 0;

    public void IncreaseMp(float _val)
    {
        mp += _val;
        if(mp > mpMax)
        {
            mp = mpMax;
        }

        if (photonView.IsMine)
        {
            uiSliderDic["MP"].slider.value = mp;
        }
    }

    public void DecreaseMp(float _val)
    {
        mp -= _val;
        if (mp < 0)
        {
            mp = 0f;
        }

        if (photonView.IsMine)
        {
            uiSliderDic["MP"].slider.value = mp;
        }
    }

    [SerializeField]
    MaterialBlink materialBlink;

    [SerializeField]
    float recoverMp = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;

        mp = mpMax;

        uiSliderDic = uiSliderTable.GetTable();

        if (photonView.IsMine)
        {
            uiSliderDic["HP"].slider.maxValue = hpMax;
            uiSliderDic["HP"].slider.value = hp;
            uiSliderDic["MP"].slider.maxValue = mpMax;
            uiSliderDic["MP"].slider.value = mp;
        }
        else
        {
            uiSliderDic["HPforOther"].slider.maxValue = hpMax;
            uiSliderDic["HPforOther"].slider.value = hp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseMp(recoverMp);
    }

    private void LateUpdate()
    {
        if (photonView.IsMine)
        {
            uiSliderDic["HP"].slider.value = hp;
            uiSliderDic["MP"].slider.value = mp;
        }
        else
        {
            uiSliderDic["HPforOther"].slider.value = hp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerAttack")
        {
            //if (other.gameObject.GetComponent<AttackManager>() != null)
            //{
            //    hp -= other.gameObject.GetComponent<AttackManager>().AttackPower;
            //}
            //else
            //{
            //    photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            //}
            photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            materialBlink.BlinkStart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            //if (collision.gameObject.GetComponent<AttackManager>() != null)
            //{
            //    hp -= collision.gameObject.GetComponent<AttackManager>().AttackPower;
            //}
            //else
            //{
                
            //}
            photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            materialBlink.BlinkStart();
        }
    }

    [PunRPC]
    public void RPCDamage()
    {
        DecreaseHp(5);
    }
}
