using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfMovement : MonoBehaviour
{
    public Vector3 amountOfMovementVec { get; private set; }

    Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        amountOfMovementVec = transform.position - oldPos;
        oldPos = transform.position;
    }
}
