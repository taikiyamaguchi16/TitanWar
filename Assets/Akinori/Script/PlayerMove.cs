using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool cursorLock;
    //移動速度。Inspectorから数値を変更できる。外部のクラスからは変更できない。
    [SerializeField] float moveSpeed;
    //Rigidbody型のplayerRidigbody変数を宣言
    Rigidbody playerRigidbody;
    //小数型の変数を２つ宣言
    float moveX, moveZ;
    //真偽値型の変数を２つ宣言
    bool moveZpermission, moveXpermission;
    //マウスの動きを取得する為のfloat型変数を宣言
    float mouseX, mouseY;
    //カメラのX回転角を取得する為のfloat型変数を宣言
    float rotationXcamera;
    //マウスの動きを反映させる許可を決める
    bool mouseXpermission, mouseYpermission;
    //カメラの動きを制御する
    Transform transformCamera;
    //Start is called before the first frame update
    //最初のフレームだけ実行される処理
    void Start()
    {
        
        //このスクリプトがアタッチされているオブジェクト(Player)のRigidbodyを取得
        playerRigidbody = GetComponent<Rigidbody>();
        //カメラのTransformを取得
        transformCamera = Camera.main.transform;
        //カメラのX回転角を取得
        rotationXcamera = transformCamera.localEulerAngles.x;
    }
    //Update is called once per frame
    //毎フレーム実行される処理
    void Update()
    {
        Application.targetFrameRate = 60;
        Debug.Log(Application.targetFrameRate);
        movePermission();

        UpdateCursorLock();
    }
    void FixedUpdate()
    {
        moveExecution();
    }
    void movePermission() 
    {
        //小数型の変数に、Horizontalで指定したキーに対して入力があった場合、度合いに応じた戻り値「-1」～「1」が割り当てられる
        moveX = Input.GetAxis("Horizontal");
        //小数型の変数に、Verticalで指定したキーに対して入力があった場合、度合いに応じた戻り値「-1」～「1」が割り当てられる
        moveZ = Input.GetAxis("Vertical");
        //マウスの上下移動に対して戻り値「-1」～「1」を取得
        mouseX = Input.GetAxis("Mouse X");
        //マウスの左右移動に対して戻り値「-1」～「1」を取得
        mouseY = Input.GetAxis("Mouse Y");
        //Verticalで指定したキーに対して入力があった場合
        if (moveZ != 0)
        {
            //前後に移動する処理を開始する為の許可を出す
            moveZpermission = true;
        }
        //Horizontalで指定したキーに対して入力があった場合
        if (moveX != 0)
        {
            //左右に移動する処理を開始する為の許可を出す
            moveXpermission = true;
        }
        if (mouseX != 0)
        {
            mouseXpermission = true;
        }
        if (mouseY != 0)
        {
            mouseYpermission = true;
        }
    }
    void moveExecution() 
    {
        //前後もしくは左右に移動する処理開始の許可が出たら、{}内の処理を実行する
        if (moveZpermission || moveXpermission || mouseXpermission || mouseYpermission)
        {
            //キー入力が無い時まで{}内の処理が呼ばれないよう、不許可に戻しておく
            moveZpermission = false;
            moveXpermission = false;
            mouseXpermission = false;
            mouseYpermission = false;
            //このスクリプトがアタッチされているオブジェクト(Player)の向きを基準としたX方向とZ方向に移動するよう、
            //１フレームの変化量に対応させてplayerRigidbodyの速度を上書きする
            //回転移動防止の為、インスペクターからFreezeRotation X Y Z にチェックを入れておく
            playerRigidbody.velocity = transform.rotation * new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime * 100;
            //マウスの左右移動に応じてプレイヤーのRigidbodyのY軸を回転
            playerRigidbody.MoveRotation(Quaternion.Euler(0.0f, playerRigidbody.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f, 0.0f));
            //transform.rotation = Quaternion.Euler(0.0f, playerRigidbody.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f, 0.0f);
            //マウスの上下移動に応じてカメラのX回転角の値を決める。+-方向40度までに制限をかける。
            rotationXcamera = Mathf.Clamp(rotationXcamera - mouseY * Time.deltaTime * 100.0f, -40, 40);
            //カメラのX回転角を設定
            transformCamera.localEulerAngles = new Vector3(rotationXcamera, 0, 0);
        }
        else
        {
            //移動許可が出ていない時は力を加えないようにリセットする
            playerRigidbody.velocity = Vector3.zero;
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