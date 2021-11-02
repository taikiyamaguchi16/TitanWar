using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal_S : MonoBehaviour
{
    private Vector3 endPos;
    private float intervalTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (intervalTime > 0)
        {
            intervalTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("StartPoint");
        if (collision.transform.tag == "Player" && intervalTime <= 0)
        {
            
            transform.parent.GetComponent<Potal>().GetEndPoint().GetComponent<Potal_E>().SetIntervalTime(transform.parent.GetComponent<Potal>().intervalTime);
            collision.transform.position = endPos;
        }
    }
    
    public void SetEndPos(Vector3 _pos)
    {
        endPos = _pos;
    }

    public void SetIntervalTime(float _time)
    {
        intervalTime = _time;
    }
}
