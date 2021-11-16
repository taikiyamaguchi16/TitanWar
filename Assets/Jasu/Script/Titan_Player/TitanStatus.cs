using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanStatus : SliderValue
{
    [SerializeField]
    float hpMax = 100f;

    float hp;

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
}
