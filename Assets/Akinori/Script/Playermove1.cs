using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove1 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    public float sensityvity = 1;
    bool cursorLock;

    float x;

    // Use this for initialization
    void Start()
    {

        PlayerTransform = transform.parent;
        CameraTransform = GetComponent<Transform>();
        x = CameraTransform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X") * sensityvity;
        float Y_Rotation = Input.GetAxis("Mouse Y") * sensityvity;

        PlayerTransform.transform.Rotate(0, X_Rotation, 0);
        // CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
        x = Mathf.Clamp(x - Y_Rotation /** Time.deltaTime * 100.0f*/, -40, 40);
        //Debug.Log(x);
        CameraTransform.transform.localEulerAngles = new Vector3(x, 0, 0);


        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));


        if (Input.GetKey(KeyCode.W))
        {
            PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
        }
        
        UpdateCursorLock();
    }

    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
