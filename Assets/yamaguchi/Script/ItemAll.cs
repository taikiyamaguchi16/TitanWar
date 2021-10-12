using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemAll : MonoBehaviour
{
    [SerializeField] Component state;

    // 2. Interfaceを取得してキャッシュ
    IPlayerAction logger = null;
    IPlayerAction Logger
    {
        get
        {
            if (logger == null)
                logger = state.GetComponent<IPlayerAction>();
            return logger;
        }
    }

    private void Start()
    {
        Logger.StartPlayerAction();
    }
}
