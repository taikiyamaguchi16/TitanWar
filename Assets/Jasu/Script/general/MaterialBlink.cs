using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBlink : MonoBehaviour
{
    [SerializeField]
    Material material;

    [SerializeField]
    Color blinkColor;

    [SerializeField]
    float blinkingTimeSeconds = 1f;

    float blinkingTimer = 0f;

    [SerializeField]
    float blinkIntervalTimeSeconds = 0.2f;

    float blinkIntervalTimer = 0f;

    bool isBlinking = false;

    bool isRising = true;

    Color matDefaultColor;

    // Start is called before the first frame update
    void Start()
    {
        matDefaultColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BlinkStart();
        }

        if (isBlinking)
        {
            blinkingTimer += Time.deltaTime;

            blinkIntervalTimer += Time.deltaTime;
            if (isRising)
            {
                material.color = Color.Lerp(matDefaultColor, blinkColor, blinkIntervalTimer / blinkIntervalTimeSeconds);
                if(blinkIntervalTimer > blinkIntervalTimeSeconds)
                {
                    blinkIntervalTimer = 0f;
                    isRising = false;
                }
            }
            else
            {
                material.color = Color.Lerp(blinkColor, matDefaultColor, blinkIntervalTimer / blinkIntervalTimeSeconds);
                if (blinkIntervalTimer > blinkIntervalTimeSeconds)
                {
                    blinkIntervalTimer = 0f;
                    isRising = false;
                }
            }

            if(blinkingTimer > blinkingTimeSeconds)
            {
                isBlinking = false;
                material.color = matDefaultColor;
            }
        }
    }

    private void OnDestroy()
    {
        isBlinking = false;
        material.color = matDefaultColor;
    }

    public void BlinkStart()
    {
        isBlinking = true;
        isRising = true;
        blinkingTimer = 0f;
        blinkIntervalTimer = 0f;
    }
}
