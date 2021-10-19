using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HandCollider : MonoBehaviour
{
    [SerializeField]
    Collider simpleCollider;

    [SerializeField]
    Collider[] colliders = null;

    [SerializeField]
    bool simpleColliderEnable = false;

    [SerializeField]
    bool detailedColliderEnable = true;

    bool firstUpdate = false;

    void Awake()
    {
        colliders = this.GetComponentsInChildren<Collider>().Where(childCollider => !childCollider.isTrigger).ToArray();
        foreach (var c in colliders)
        {
            c.isTrigger = true;
        }

        //Debug.Log("コライダー奪取");
    }

    // Start is called before the first frame update
    void Start()
    {
        firstUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstUpdate)
        {
            foreach (var c in colliders)
            {
                c.isTrigger = false;
                c.enabled = detailedColliderEnable;
            }
            firstUpdate = false;
            
            simpleCollider.isTrigger = false;
            simpleCollider.enabled = simpleColliderEnable;
        }
    }

    public Collider GetHandSimpleCollider()
    {
        return simpleCollider;
    }

    public bool GetSimpleColliderEnable()
    {
        return simpleColliderEnable;
    }

    public Collider[] GetHandDetailedColliders()
    {
        return colliders;
    }

    public bool GetDetailedColliderEnable()
    {
        return detailedColliderEnable;
    }
}
