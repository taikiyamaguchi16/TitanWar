using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject weaponFrame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //print("���{�^����������Ă���");
            weaponFrame.transform.GetChild(0).GetComponent<IPlayerAction>().InPlayerAction();
           // GetComponent<IPlayerAction>().InPlayerAction();
        }
        if (Input.GetMouseButton(1))
        {
            //print("�E�{�^����������Ă���");
        }
        if (Input.GetMouseButton(2))
        {
            //print("���{�^����������Ă���");
        }
    }
}
//RpcShot

//CallShot