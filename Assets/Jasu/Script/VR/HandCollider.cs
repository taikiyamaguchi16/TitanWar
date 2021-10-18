using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HandCollider : MonoBehaviour
{
    [SerializeField]
    Collider[] m_colliders = null;

    bool firstUpdate = false;

    void Awake()
    {
        m_colliders = this.GetComponentsInChildren<Collider>().Where(childCollider => !childCollider.isTrigger).ToArray();
        foreach (var c in m_colliders)
        {
            c.isTrigger = true;
        }

        Debug.Log("奪取");
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
            foreach (var c in m_colliders)
            {
                c.isTrigger = false;
                c.enabled = true;
            }
            firstUpdate = false;
        }
    }
}
