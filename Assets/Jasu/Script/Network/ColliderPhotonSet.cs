using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;

public class ColliderPhotonSet : MonoBehaviour
{
    [SerializeField]
    HandCollider handCollider;

    // Start is called before the first frame update
    void Start()
    {
        if (handCollider.GetDetailedColliderEnable())
        {
            Collider[] colliders = handCollider.GetHandDetailedColliders();
            foreach (var col in colliders)
            {
                col.gameObject.AddComponent<PhotonTransformView>();
            }
        }

        if (handCollider.GetSimpleColliderEnable())
        {
            handCollider.GetHandSimpleCollider().gameObject.AddComponent<PhotonTransformView>();
        }
    }
}
