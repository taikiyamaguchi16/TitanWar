using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal_E : MonoBehaviour
{
    private Vector3 startPos;
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
        if (collision.transform.tag == "Player" && intervalTime <= 0)
        {
            transform.parent.GetComponent<Potal>().GetStartPoint().GetComponent<Potal_S>().SetIntervalTime(transform.parent.GetComponent<Potal>().intervalTime);
            collision.transform.position = startPos;
        }
    }

    public void SetStartPos(Vector3 _pos)
    {
        startPos = _pos;
    }

    public void SetIntervalTime(float _time)
    {
        intervalTime = _time;
    }
}
