using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    public float Hp;
    public float ultPower;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 100;
        ultPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TitanAttack")
        {
            Hp -= 1;
        }
    }
}
