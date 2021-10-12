using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct PlayerActionDesc
{
    GameObject target;
}
public interface IPlayerAction
{
    void StartPlayerAction();
}

public  class ItemBase : MonoBehaviour,IPlayerAction
{
    public delegate void OnCompleteDelegate();
    public OnCompleteDelegate CompleteHandler;

    protected int bulletNum;

    public void OutOfAmmo()
    {
        Debug.Log("コールバック関数の起動");
        CompleteHandler?.Invoke();
    }
    public virtual void StartPlayerAction()
    {
        Debug.Log("元のインターフェース実行中");
    }

}
