using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBase : MonoBehaviour {
    

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
