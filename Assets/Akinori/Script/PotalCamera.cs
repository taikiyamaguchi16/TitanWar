using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PotalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform potal;
    public Transform otherPotal;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform;
    }

    private void Update()
    {
        Vector3 playerOffsetFromPotal = playerCamera.position - otherPotal.position;
        //transform.position = potal.position + playerOffsetFromPotal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(potal.rotation, otherPotal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}
