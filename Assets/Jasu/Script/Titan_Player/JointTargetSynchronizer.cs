using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointTargetSynchronizer : MonoBehaviour
{
    [SerializeField]
    ConfigurableJoint configurableJoint;

    [SerializeField]
    Transform controllerTrans;

    [SerializeField]
    Transform synchronizedTargetTrans = null;

    [SerializeField]
    float localPositionMultiply = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        configurableJoint.targetPosition = controllerTrans.localPosition * localPositionMultiply;
        synchronizedTargetTrans.localRotation = controllerTrans.localRotation;
    }
}
