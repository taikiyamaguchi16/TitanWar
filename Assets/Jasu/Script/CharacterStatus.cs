using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

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

    ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();

    [SerializeField]
    protected float hpMax = 100f;
    
    public float hp { get; protected set; } = 0;

    protected void IncreaseHp(float _val)
    {
        if (photonView.IsMine)
        {
            hp += _val;
            if (hp > hpMax)
            {
                hp = hpMax;
            }

            uiSliderDic["HP"].slider.value = hp;
            hashtable["HP"] = hp;
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
        }
    }

    protected void DecreaseHp(float _val)
    {
        if (photonView.IsMine)
        {
            hp -= _val;
            if (hp < 0)
            {
                hp = 0f;
            }

            uiSliderDic["HP"].slider.value = hp;
            hashtable["HP"] = hp;
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    protected void OnStart()
    {
        hp = hpMax;

        uiSliderDic = uiSliderTable.GetTable();

        if (photonView.IsMine)
        {
            uiSliderDic["HP"].slider.maxValue = hpMax;
            uiSliderDic["HP"].slider.value = hp;
            hashtable.Add("HP", hp);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
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
        OnLateUpdate();
    }

    protected void OnLateUpdate()
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

    public void TakeDamage(float _damage)
    {
        DecreaseHp(_damage);
    }

    //public void CallTakeDamage(float _damage)
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        photonView.RPC(nameof(RPCDamage), RpcTarget.All, _damage);
    //    }
    //}

    //[PunRPC]
    //protected void RPCDamage(float _damage)
    //{
    //    DecreaseHp(_damage);
    //}

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(!photonView.IsMine && photonView.Owner.ActorNumber == targetPlayer.ActorNumber)
        {
            hp = (targetPlayer.CustomProperties["HP"] is int value) ? value: 0;
        }
    }

    protected void OnDestroy()
    {
        if (photonView.IsMine)
        {
            hashtable.Clear();
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
        }
    }
}
