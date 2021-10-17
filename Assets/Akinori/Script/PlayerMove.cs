using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    public float sensityvity = 1;
    bool cursorLock;

    float accel = 1;
    float x;
    Rigidbody rb;

    bool Crouching;
    
    [SerializeField]
    float DashSpeed;
    [SerializeField]
    float JanpSpeed;
    [SerializeField]
    float WalkSpeed;
    [SerializeField]
    float CrouchingSpeed;
    [SerializeField]
    // Use this for initialization
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        CameraTransform = transform.Find("Main Camera").gameObject.transform;
        //PlayerTransform = transform.parent;
        //CameraTransform = GetComponent<Transform>();
        x = CameraTransform.localEulerAngles.x;
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X") * sensityvity;
        float Y_Rotation = Input.GetAxis("Mouse Y") * sensityvity;

        //カメラとキャラクターの回転
        PlayerTransform.transform.Rotate(0, X_Rotation, 0);       
        x = Mathf.Clamp(x - Y_Rotation /** Time.deltaTime * 100.0f*/, -40, 40);
        CameraTransform.transform.localEulerAngles = new Vector3(x, 0, 0);


        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            if (accel < 1.3f)
            {
                accel += 0.1f;
            }
        }
        else
        {
            accel = 1f;
        }

        // if (!transform.GetComponent<PlayerJump>().GetIsJump())
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

        //if (Input.GetKeyDown(KeyCode.C) && Crouching == false)
        //{
        //    Crouching = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.C) && Crouching == true)
        //{
        //    Crouching = false;
        //}

        //if (Crouching == true)
        //{
        //    Camera.transform.position = new Vector3(transform.position.x, transform.position.y + 0.619f, transform.position.z);
        //    speed = CrouchingSpeed;
        //}
        //else
        //{
        //    Camera.transform.position = new Vector3(transform.position.x, transform.position.y + 1.238f, transform.position.z);
        //}


        //////////////////////////////////////
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    speed = DashSpeed;
        //}
        //else if (Crouching == false)
        //{
        //    speed = WalkSpeed;
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    var tmp = transform.forward * speed - rb.velocity;
        //    tmp.y = 0;
        //    rb.AddForce(tmp);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    var tmp = -transform.right * speed - rb.velocity;
        //    tmp.y = 0;
        //    rb.AddForce(tmp);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    var tmp = transform.right * speed - rb.velocity;
        //    tmp.y = 0;
        //    rb.AddForce(tmp);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    var tmp = -transform.forward * speed - rb.velocity;
        //    tmp.y = 0;
        //    rb.AddForce(tmp);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, JanpSpeed, rb.velocity.z);
        //}


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
