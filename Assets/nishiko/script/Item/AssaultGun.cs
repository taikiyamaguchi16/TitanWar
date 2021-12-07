using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AssaultGun : MonoBehaviourPunCallbacks, IPlayerAction
{
    [SerializeField]
    private BasicItemInformation parameter;

    [Header("�e�A�C�e���̓Ǝ��p�����[�^")]
    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    private GameObject muzzleflash;
    public AudioClip shotSE;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (photonView.IsMine)
                InPlayerAction();
        }

    }

    public void InPlayerAction()
    {
        parameter.ElapsedTime += Time.deltaTime;
        if (parameter.BulletNum > 0 && !parameter.isReloadNow)
        {
            if (parameter.RateTime < parameter.ElapsedTime)
            {
                Instantiate(muzzleflash, this.transform.GetChild(0).position, this.transform.GetChild(0).rotation);
                AudioSource.PlayClipAtPoint(shotSE, transform.position);
                photonView.RPC(nameof(Shot), RpcTarget.AllViaServer);
                parameter.BulletNum--;
                parameter.ElapsedTime = 0f;
            }
        }
    }

    public void EndPlayerAction()
    {

    }

    [PunRPC]
    private void Shot()
    {
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = PhotonNetwork.Instantiate(bullet.name, transform.GetChild(0).transform.position, transform.rotation);
        newBall.transform.parent = this.transform;
        // �o���������{�[����forward(z������)
        Vector3 direction = newBall.transform.forward;
        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBall.GetComponent<Rigidbody>().AddForce(direction * parameter.Speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
    }
}
