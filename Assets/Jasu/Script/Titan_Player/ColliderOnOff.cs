using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOnOff : MonoBehaviour
{
    [SerializeField]
    List<Collider> colliders = new List<Collider>();

    public void CollidersEnable(bool _enable)
    {
        foreach(var collider in colliders)
        {
            collider.enabled = _enable;
        }
    }
}
