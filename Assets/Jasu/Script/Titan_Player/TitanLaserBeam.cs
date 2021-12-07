using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanLaserBeam : MonoBehaviour
{
    [SerializeField]
    GameObject laserBeamPrefab = null;

    [SerializeField]
    Transform shootTransL = null;

    [SerializeField]
    Transform shootTransR = null;

    GameObject laserBeamL;

    GameObject laserBeamR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) &&
              OVRInput.Get(OVRInput.RawButton.LHandTrigger) &&
              OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            laserBeamL = Instantiate(laserBeamPrefab, shootTransL);
            Vector3 rotVec = laserBeamL.transform.localEulerAngles;
            rotVec.y = -90;
            laserBeamL.transform.localRotation = Quaternion.Euler(rotVec);
        }

        if (OVRInput.GetUp(OVRInput.RawButton.Y) && laserBeamL != null)
        {
            Destroy(laserBeamL);
            laserBeamL = null;
        }

        if (!OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) &&
                OVRInput.Get(OVRInput.RawButton.RHandTrigger) &&
                OVRInput.GetDown(OVRInput.RawButton.B))
        {
            laserBeamR = Instantiate(laserBeamPrefab, shootTransR);
            Vector3 rotVec = laserBeamR.transform.localEulerAngles;
            rotVec.y = 90;
            laserBeamR.transform.localRotation = Quaternion.Euler(rotVec);
        }

        if (OVRInput.GetUp(OVRInput.RawButton.B) && laserBeamR != null)
        {
            Destroy(laserBeamR);
            laserBeamR = null;
        }
    }
}
