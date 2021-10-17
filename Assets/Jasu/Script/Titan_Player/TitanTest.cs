using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanTest : MonoBehaviour
{
    [SerializeField]
    ColliderOnOff colliderManagerLHand;

    [SerializeField]
    ColliderOnOff colliderManagerRHand;

    // Start is called before the first frame update
    void Start()
    {
        colliderManagerRHand.CollidersEnable(true);
        colliderManagerLHand.CollidersEnable(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            colliderManagerRHand.CollidersEnable(true);
        }
        else
        {
            colliderManagerRHand.CollidersEnable(false);
        }

        if (OVRInput.Get(OVRInput.RawButton.Y))
        {
            colliderManagerLHand.CollidersEnable(true);
        }
        else
        {
            colliderManagerLHand.CollidersEnable(false);
        }
    }
}
