using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPos;
    [SerializeField]
    private Vector3 endPos;

    [SerializeField]
    private GameObject startPoint;
    [SerializeField]
    private GameObject endPoint;

    public float intervalTime = 2;

    public float susTime = 60;
    // Start is called before the first frame update


    public void SetStartPoint(Vector3 _pos)
    {
        
        //startPoint.transform.parent = this.transform;
        startPos = _pos;
    }
    public void SetEndPoint(Vector3 _pos)
    {
        var parent = this.transform;
        endPos = _pos;


        Instantiate(startPoint, startPos, Quaternion.identity);
        Instantiate(endPoint, endPos, Quaternion.identity);

        GameObject s, e;
        s = GameObject.Find("startPoint(Clone)");
        e = GameObject.Find("endPoint(Clone)");


        s.GetComponent<Potal_S>().SetEndPos(endPos);
        s.GetComponent<Potal_S>().SetIntervalTime(intervalTime);
        s.GetComponent<Potal_S>().SetOtherPotalCamera(e.transform.GetChild(0).GetComponent<Camera>());
        
        

        
        e.GetComponent<Potal_E>().SetStartPos(startPos);
        e.GetComponent<Potal_E>().SetIntervalTime(intervalTime);
        e.GetComponent<Potal_E>().SetOtherPotalCamera(s.transform.GetChild(0).GetComponent<Camera>());
        e.GetComponent<Potal_E>().GateOpen();
        s.GetComponent<Potal_S>().GateOpen();

        

        

        s.GetComponent<Potal_S>().SetEndPoint(e);
        e.GetComponent<Potal_E>().SetStartPoint(s);

    }
    public float GetIntervalTime()
    {
        return intervalTime;
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
