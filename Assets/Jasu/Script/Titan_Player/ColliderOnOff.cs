using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColliderOnOff : MonoBehaviour
{
    [SerializeField]
    List<Collider> colliderList = new List<Collider>();

    bool collidersEnable;

    public void Start()
    {
        Collider[] colliders =
            GetComponentsInChildren<Collider>().Where(childCollider => !childCollider.isTrigger).ToArray();
        colliderList.AddRange(colliders);
    }

    public void CollidersEnable(bool _enable)
    {
        collidersEnable = _enable;
        foreach(var collider in colliderList)
        {
            collider.enabled = _enable;
        }
    }

    public bool GetCollidersEnable()
    {
        return collidersEnable;
    }
}
