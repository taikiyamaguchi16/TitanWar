using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;

public class ColliderPhotonSet : MonoBehaviour
{
    [SerializeField]
    List<Collider> colliderList = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders =
            this.GetComponentsInChildren<Collider>().Where(childCollider => !childCollider.isTrigger).ToArray();
        colliderList.AddRange(colliders);

        foreach (var col in colliderList)
        {
            col.gameObject.AddComponent<PhotonTransformView>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
