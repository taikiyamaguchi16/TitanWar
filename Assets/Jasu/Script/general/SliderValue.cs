using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SliderValue : MonoBehaviourPunCallbacks
{
    public float sliderValue { get; protected set; }

    public float sliderMaxValue { get; protected set; }
}
