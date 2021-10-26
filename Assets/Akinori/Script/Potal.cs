using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    private GameObject startPoint;
    private GameObject endPoint;

    public float intervalTime = 2;

    public float susTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.GetChild(0).gameObject;
        endPoint = transform.GetChild(1).gameObject;

        startPoint.GetComponent<Potal_S>().SetEndPos(endPoint.transform.position);
        endPoint.GetComponent<Potal_E>().SetStartPos(startPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        susTime -= Time.deltaTime;
        //if (susTime <= 0)
        //{
        //    Destroy(this);
        //}
    }


    public void SetStartPoint(Vector3 _pos)
    {
        startPos = _pos;
    }
    public void SetEndPoint(Vector3 _pos)
    {
        endPos = _pos;
    }
    public float GetIntervalTime()
    {
        return intervalTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.tag == "Player")
        //{

        //}
    }

    public GameObject GetStartPoint()
    {
        return startPoint;
    }
    public GameObject GetEndPoint()
    {
        return endPoint;
    }
}
