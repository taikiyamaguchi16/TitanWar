using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool cursorLock;
    //�ړ����x�BInspector���琔�l��ύX�ł���B�O���̃N���X����͕ύX�ł��Ȃ��B
    [SerializeField] float moveSpeed;
    //Rigidbody�^��playerRidigbody�ϐ���錾
    Rigidbody playerRigidbody;
    //�����^�̕ϐ����Q�錾
    float moveX, moveZ;
    //�^�U�l�^�̕ϐ����Q�錾
    bool moveZpermission, moveXpermission;
    //�}�E�X�̓������擾����ׂ�float�^�ϐ���錾
    float mouseX, mouseY;
    //�J������X��]�p���擾����ׂ�float�^�ϐ���錾
    float rotationXcamera;
    //�}�E�X�̓����𔽉f�����鋖�����߂�
    bool mouseXpermission, mouseYpermission;
    //�J�����̓����𐧌䂷��
    Transform transformCamera;
    //Start is called before the first frame update
    //�ŏ��̃t���[���������s����鏈��
    void Start()
    {
        
        //���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g(Player)��Rigidbody���擾
        playerRigidbody = GetComponent<Rigidbody>();
        //�J������Transform���擾
        transformCamera = Camera.main.transform;
        //�J������X��]�p���擾
        rotationXcamera = transformCamera.localEulerAngles.x;
    }
    //Update is called once per frame
    //���t���[�����s����鏈��
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
        //�����^�̕ϐ��ɁAHorizontal�Ŏw�肵���L�[�ɑ΂��ē��͂��������ꍇ�A�x�����ɉ������߂�l�u-1�v�`�u1�v�����蓖�Ă���
        moveX = Input.GetAxis("Horizontal");
        //�����^�̕ϐ��ɁAVertical�Ŏw�肵���L�[�ɑ΂��ē��͂��������ꍇ�A�x�����ɉ������߂�l�u-1�v�`�u1�v�����蓖�Ă���
        moveZ = Input.GetAxis("Vertical");
        //�}�E�X�̏㉺�ړ��ɑ΂��Ė߂�l�u-1�v�`�u1�v���擾
        mouseX = Input.GetAxis("Mouse X");
        //�}�E�X�̍��E�ړ��ɑ΂��Ė߂�l�u-1�v�`�u1�v���擾
        mouseY = Input.GetAxis("Mouse Y");
        //Vertical�Ŏw�肵���L�[�ɑ΂��ē��͂��������ꍇ
        if (moveZ != 0)
        {
            //�O��Ɉړ����鏈�����J�n����ׂ̋����o��
            moveZpermission = true;
        }
        //Horizontal�Ŏw�肵���L�[�ɑ΂��ē��͂��������ꍇ
        if (moveX != 0)
        {
            //���E�Ɉړ����鏈�����J�n����ׂ̋����o��
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
        //�O��������͍��E�Ɉړ����鏈���J�n�̋����o����A{}���̏��������s����
        if (moveZpermission || moveXpermission || mouseXpermission || mouseYpermission)
        {
            //�L�[���͂��������܂�{}���̏������Ă΂�Ȃ��悤�A�s���ɖ߂��Ă���
            moveZpermission = false;
            moveXpermission = false;
            mouseXpermission = false;
            mouseYpermission = false;
            //���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g(Player)�̌�������Ƃ���X������Z�����Ɉړ�����悤�A
            //�P�t���[���̕ω��ʂɑΉ�������playerRigidbody�̑��x���㏑������
            //��]�ړ��h�~�ׁ̈A�C���X�y�N�^�[����FreezeRotation X Y Z �Ƀ`�F�b�N�����Ă���
            playerRigidbody.velocity = transform.rotation * new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime * 100;
            //�}�E�X�̍��E�ړ��ɉ����ăv���C���[��Rigidbody��Y������]
            playerRigidbody.MoveRotation(Quaternion.Euler(0.0f, playerRigidbody.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f, 0.0f));
            //transform.rotation = Quaternion.Euler(0.0f, playerRigidbody.rotation.eulerAngles.y + mouseX * Time.deltaTime * 100.0f, 0.0f);
            //�}�E�X�̏㉺�ړ��ɉ����ăJ������X��]�p�̒l�����߂�B+-����40�x�܂łɐ�����������B
            rotationXcamera = Mathf.Clamp(rotationXcamera - mouseY * Time.deltaTime * 100.0f, -40, 40);
            //�J������X��]�p��ݒ�
            transformCamera.localEulerAngles = new Vector3(rotationXcamera, 0, 0);
        }
        else
        {
            //�ړ������o�Ă��Ȃ����͗͂������Ȃ��悤�Ƀ��Z�b�g����
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