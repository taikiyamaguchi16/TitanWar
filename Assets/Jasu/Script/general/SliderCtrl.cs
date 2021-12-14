using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ColorInRatio
{
    [Tooltip("����(0~1)")] public float ratio;
    [Tooltip("UI�J���[")] public Color color;
}

public class SliderCtrl : MonoBehaviour
{
    //[SerializeField]
    public Slider slider;

    [SerializeField]
    List<ColorInRatio> colorInRatios = new List<ColorInRatio>();

    [SerializeField]
    Image fillImage;

    [SerializeField]
    bool colorGradation = false;

    // Start is called before the first frame update
    void Start()
    {
        // �\�[�g
        for (int i = 0; i < colorInRatios.Count; i++)
        {
            for (int j = i + 1; j < colorInRatios.Count; j++)
            {
                if (colorInRatios[i].ratio < colorInRatios[j].ratio)
                {
                    ColorInRatio tmp = colorInRatios[i];
                    colorInRatios[i] = colorInRatios[j];
                    colorInRatios[j] = tmp;
                }
            }
        }
    }

    private void LateUpdate()
    {
        // �l����J���[����
        float ratio = slider.value / slider.maxValue;

        for (int i = 0; i < colorInRatios.Count; i++)
        {
            if (ratio <= colorInRatios[i].ratio)
            {
                if (colorGradation)
                {
                    if (i == colorInRatios.Count - 1)
                    {
                        fillImage.color = colorInRatios[i].color;
                    }
                    else
                    {
                        fillImage.color = Color.Lerp(colorInRatios[i + 1].color, colorInRatios[i].color,
                            (ratio - colorInRatios[i + 1].ratio) / (colorInRatios[i].ratio - colorInRatios[i + 1].ratio));
                    }
                }
                else
                {
                    fillImage.color = colorInRatios[i].color;
                }
            }
        }
    }

    //void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        // ���g�̃A�o�^�[�̒l�𑗐M����
    //        stream.SendNext(slider.value);
    //    }
    //    else
    //    {
    //        // ���v���C���[�̃A�o�^�[�̒l����M����
    //        slider.value = (float)stream.ReceiveNext();
    //    }
    //}
}

