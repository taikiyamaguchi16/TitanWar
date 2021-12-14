using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRotationSynchronizer : MonoBehaviour
{
    //[SerializeField]
    //Transform synchronizedTargetTrans = null;

    [SerializeField]
    Transform controllerTrans = null;

    [SerializeField]
    ConfigurableJoint configurableJoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //synchronizedTargetTrans.rotation = controllerTrans.localRotation;
        configurableJoint.targetRotation = controllerTrans.localRotation;
    }
}
