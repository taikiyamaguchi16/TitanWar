using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviourPunCallbacks
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    public float sensityvity = 1;
    bool cursorLock;

    public float accel = 1;
    float x;
    Rigidbody rb;

    bool isCrouching;
    GameObject cam;
    Vector3 crouchCameraPos;
    Vector3 cameraPos;

    public bool isReloading;

    //[SerializeField]
    //float DashSpeed;
    //[SerializeField]
    //float JanpSpeed;
    //[SerializeField]
    //float WalkSpeed;
    //[SerializeField]
    //float isCrouchingSpeed;
    //[SerializeField]
    // Use this for initialization
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();        
        rb = Player.GetComponent<Rigidbody>();

        if (photonView.IsMine)
        {
            Player owner = photonView.Owner;

            cam = GameObject.FindGameObjectWithTag("MainCamera");
            cam.transform.parent = this.transform; 
            x = cam.transform.localEulerAngles.x;
            cam.transform.position = transform.Find("MainCameraPos").transform.position;
            cameraPos = transform.Find("MainCameraPos").transform.position;
            crouchCameraPos = transform.Find("CrouchCameraPos").transform.position;

            transform.Find("WeaponFrame").transform.parent = cam.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float X_Rotation = Input.GetAxis("Mouse X") * sensityvity;
            float Y_Rotation = Input.GetAxis("Mouse Y") * sensityvity;

            //カメラとキャラクターの回転
            PlayerTransform.transform.Rotate(0, X_Rotation, 0);
            x = Mathf.Clamp(x - Y_Rotation /** Time.deltaTime * 100.0f*/, -60, 60);
            //CameraTransform.transform.localEulerAngles = new Vector3(x, 0, 0);

            cam.transform.localEulerAngles = new Vector3(x, 0, 0);

            float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
            Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !isCrouching)
            {
                if (accel <= 1.5f)
                {                   
                    accel = 1.5f;
                }
                else
                {
                    accel -= Time.deltaTime;
                }
                if (Input.GetKeyDown(KeyCode.C) )
                {
                    accel = 3.0f;
                }
            }
            else
            {
                accel -= Time.deltaTime;
                if (accel <= 1)
                {
                    accel = 1;
                }
            }

            //if(!transform.GetComponent<PlayerJump>().GetIsJump())
            {
                if (Input.GetKey(KeyCode.W))
                {
                    PlayerTransform.transform.position += dir1 * speed * accel * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    PlayerTransform.transform.position += dir2 * speed * accel * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    PlayerTransform.transform.position += -dir2 * speed * accel * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    PlayerTransform.transform.position += -dir1 * speed * accel * Time.deltaTime;
                }
            }

            if (Input.GetKeyDown(KeyCode.C) && isCrouching == false)
            {
                
                isCrouching = true;
                
            }
            else if (Input.GetKeyDown(KeyCode.C) && isCrouching == true)
            {
                isCrouching = false;
            }

            if (isCrouching == true)
            {
                cam.transform.position = transform.Find("CrouchCameraPos").transform.position;

            }
            else
            {
                cam.transform.position = transform.Find("MainCameraPos").transform.position;
            }
            UpdateCursorLock();
        }
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
