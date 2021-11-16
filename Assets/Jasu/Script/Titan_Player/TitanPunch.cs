using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanPunch : MonoBehaviour
{
    [SerializeField]
    AttackManager attackManagerL;

    [SerializeField]
    AmountOfMovement amountOfMovementL;

    [SerializeField]
    AttackManager attackManagerR;

    [SerializeField]
    AmountOfMovement amountOfMovementR;

    [SerializeField]
    float punchAmount = 1f;

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger) &&
                OVRInput.Get(OVRInput.RawButton.LHandTrigger) &&
                amountOfMovementL.amountOfMovementVec.magnitude >= punchAmount)
        {
            attackManagerL.AttackActive(true);
        }
        else
        {
            attackManagerL.AttackActive(false);
        }

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) &&
                OVRInput.Get(OVRInput.RawButton.RHandTrigger) &&
                amountOfMovementR.amountOfMovementVec.magnitude >= punchAmount)
        {
            attackManagerR.AttackActive(true);
        }
        else
        {
            attackManagerR.AttackActive(false);
        }
    }
}
