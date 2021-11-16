using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanStatus : SliderValue
{
    [SerializeField]
    float hpMax = 100f;

    [SerializeField]
    float hp = 0;

    [SerializeField]
    MaterialBlink materialBlink;

    // Start is called before the first frame update
    void Start()
    {
        sliderMaxValue = hpMax;
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerAttack")
        {
            if (other.gameObject.GetComponent<AttackManager>() != null)
            {
                hp -= other.gameObject.GetComponent<AttackManager>().AttackPower;
            }
            else
            {
                hp -= 10f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            if (collision.gameObject.GetComponent<AttackManager>() != null)
            {
                hp -= collision.gameObject.GetComponent<AttackManager>().AttackPower;
            }
            else
            {
                hp -= 10;
            }
            
            materialBlink.BlinkStart();
        }
    }
}
