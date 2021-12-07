using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    Camera targetCamera = null;

    [SerializeField]
    Canvas canvas = null;

    // Start is called before the first frame update
    void Start()
    {
        if(targetCamera == null)
        {
            targetCamera = Camera.main; 
        }

        if (canvas != null)
        {
            canvas.worldCamera = targetCamera;
        }
        else
        {
            if ((canvas = GetComponent<Canvas>()) != null)
            {
                canvas.worldCamera = targetCamera;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCamera == null)   // カメラ無くなったら次のカメラ探す
        {
            targetCamera = Camera.main;

            if (canvas != null)
            {
                canvas.worldCamera = targetCamera;
            }
            else
            {
                if ((canvas = GetComponent<Canvas>()) != null)
                {
                    canvas.worldCamera = targetCamera;
                }
            }
        }

        // lookat
        transform.LookAt(targetCamera.transform);
    }
}
