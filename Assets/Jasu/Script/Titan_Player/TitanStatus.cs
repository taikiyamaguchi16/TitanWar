using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TitanStatus : CharacterStatus
{
    [SerializeField]
    float mpMax = 100f;
    
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
        mp = mpMax;

        OnStart();
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
            TakeDamage(5);
            materialBlink.BlinkStart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            TakeDamage(5);
            materialBlink.BlinkStart();
        }
    }
}
