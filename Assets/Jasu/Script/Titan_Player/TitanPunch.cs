using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanPunch : MonoBehaviour
{
    [SerializeField]
    AttackManager attackManagerL;

    [SerializeField]
    AttackManager attackManagerR;

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger) &&
                OVRInput.Get(OVRInput.RawButton.LHandTrigger))
        {
            attackManagerL.AttackActive(true);
        }
        else
        {
            attackManagerL.AttackActive(false);
        }

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) &&
                OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            attackManagerR.AttackActive(true);
        }
        else
        {
            attackManagerR.AttackActive(false);
        }
    }
}
