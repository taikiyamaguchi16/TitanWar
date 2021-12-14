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


public class CharacterStatus : MonoBehaviourPunCallbacks
{
    [SerializeField]
    protected SliderCtrlToNameTable uiSliderTable;

    protected Dictionary<string, SliderCtrl> uiSliderDic = new Dictionary<string, SliderCtrl>();

    [SerializeField]
    protected float hpMax = 100f;

    [SerializeField]
    public float hp { get; private set; } = 0;

    public void IncreaseHp(float _val)
    {
        hp += _val;
        if (hp > hpMax)
        {
            hp = hpMax;
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

    public void DecreaseHp(float _val)
    {
        hp -= _val;
        if (hp < 0)
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
    float recoverMp = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;

        uiSliderDic = uiSliderTable.GetTable();

        if (photonView.IsMine)
        {
            uiSliderDic["HP"].slider.maxValue = hpMax;
            uiSliderDic["HP"].slider.value = hp;
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

    }

    private void LateUpdate()
    {
        if (photonView.IsMine)
        {
            uiSliderDic["HP"].slider.value = hp;
        }
        else
        {
            uiSliderDic["HPforOther"].slider.value = hp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC(nameof(RPCDamage), RpcTarget.All);
            }
        }
    }

    [PunRPC]
    public void RPCDamage()
    {
        DecreaseHp(5);
    }
}
