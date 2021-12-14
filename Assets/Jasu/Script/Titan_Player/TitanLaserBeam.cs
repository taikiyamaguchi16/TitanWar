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

    GameObject laserBeamL = null;

    GameObject laserBeamR = null;

    [SerializeField]
    TitanStatus titanStatus;

    [Header("パラメータ")]

    [SerializeField]
    float startConsumption = 10f;

    [SerializeField]
    float consumption = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.Y))
        {
            if (!OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) &&
                OVRInput.Get(OVRInput.RawButton.LHandTrigger) &&
                laserBeamL == null && titanStatus.mp >= startConsumption)
            {
                laserBeamL = Instantiate(laserBeamPrefab, shootTransL);
                Vector3 rotVec = laserBeamL.transform.localEulerAngles;
                rotVec.y = -90;
                laserBeamL.transform.localRotation = Quaternion.Euler(rotVec);
                titanStatus.DecreaseMp(startConsumption);
            }
        }

        if (laserBeamL != null && (!OVRInput.Get(OVRInput.RawButton.Y) || titanStatus.mp < consumption))
        {
            Destroy(laserBeamL);
            laserBeamL = null;
        }

        if(laserBeamL != null)
        {
            titanStatus.DecreaseMp(consumption);
        }

        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            if (!OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) &&
                    OVRInput.Get(OVRInput.RawButton.RHandTrigger) &&
                    laserBeamR == null && titanStatus.mp >= startConsumption)
            {
                laserBeamR = Instantiate(laserBeamPrefab, shootTransR);
                Vector3 rotVec = laserBeamR.transform.localEulerAngles;
                rotVec.y = 90;
                laserBeamR.transform.localRotation = Quaternion.Euler(rotVec);
                titanStatus.DecreaseMp(startConsumption);
            }
        }

        if (laserBeamR != null && (!OVRInput.Get(OVRInput.RawButton.B) || titanStatus.mp < consumption))
        {
            Destroy(laserBeamR);
            laserBeamR = null;
        }

        if (laserBeamR != null)
        {
            titanStatus.DecreaseMp(consumption);
        }
    }
}
