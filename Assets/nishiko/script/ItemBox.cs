using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//
#if UNITY_EDITOR
using UnityEditor;      //!< �f�v���C����Editor�X�N���v�g������ƃG���[�ɂȂ�̂� UNITY_EDITOR �Ŋ����ĂˁI
#endif

public class ItemBox : MonoBehaviour
{
    [Header("�I�����C���Ȃ�`�F�b�N������")]
    [SerializeField]
    private bool isOnline = false;


    [Header("�����Ԋu(�b��)")]
    [SerializeField] private int m_interval = 30;


    float m_time = 0f;//���Ԃ��L�^���鏬��������ϐ�.
    private bool m_isRespown = true;    //�����o���邩�H�i�����o���Ȃ��Ffalse �b�����o����Ftrue�j

    //
    public GameObject respawnItem = null;

    private float framecount=0;


    private bool m_isHitOther = false;
    //�䂭�䂭�̓��A�x���Ƃɔz��I�u�W�F�N�g�𕪂���B
    [SerializeField] private GameObject[] m_objItem;

    [SerializeField]
    private int index;


    [Header("���ꂼ��̊m��(�ォ�烌�A�x���Ⴂ)")]
    public float[] popRate = new float[3];
    private float popNum;

    [Header("���A�x�F�m�[�}��")]
    public GameObject[] normalItem;
    private string[] normalPass= { "Item/machinegun", "Item/missile", "Item/tama" };

    [Header("���A�x�F���A")]
    public GameObject[] rareItem;
    private string[] rarePass = { "Item/rare_machinegun", "Item/rare_missile"};

    [Header("���A�x�F�X�[�p�[���A")]
    public GameObject[] superItem;
    private string[] superPass = { "Item/sr_machinegun", "Item/sr_missile" };
    // Start is called before the first frame update
    void Start()
    {
        AverageRate(); //�m�����Y��ɂ���B
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        if (m_isRespown && !m_isHitOther)
        {
            int second = (int)m_time % 60;//�b.time��60�Ŋ������]��.

            if (m_interval < second)
            {
                m_time = 0f;//�^�C�����Z�b�g

                //�A�C�e������
                //PhotonView.RPC("CreateItem" , ���s������Ώۂ�PhotonPlayer [, ����1 , ����2 ...] );
                CreateItem();
                m_isRespown = false;
                framecount = 0;
            }
        }

        if (respawnItem != null)
        {
            if (respawnItem.transform.parent)//�A�C�e���̏��L�҂�player�ɂȂ����玟�̃A�C�e���̐����J�n
            {
                this.RespownReset();
            }
        }
        //if (!m_isRespown)
        //{
        //    if (respawnItem == null)
        //    {
        //        this.RespownReset();
        //    }
        //}
    }

    private void RespownReset() {
        respawnItem = null;
        m_isRespown = true;
        m_time = 0;
    }

    //�C���f�b�N�X��ݒ�
    public void SetIndex(int idx)
    {
        index = idx;
    }


    // [PunRPC]//�A�C�e�������_������
    private void RandomCreateItem()
    {
        int idx = Random.Range(0, m_objItem.Length);
        //Instantiate(m_objItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        GameObject obj = (GameObject)Instantiate(m_objItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        // �쐬�����I�u�W�F�N�g���q�Ƃ��ēo�^
        obj.transform.parent = transform;
    }
    //=====================================================================
    //�A�C�e���𐶐�(���A�x�̏d�݂ɕ����Đ����X�^�[�g)
    //=====================================================================
    private void CreateItem()
    {
        //���A�x���m�肳���ăA�C�e���������_������
        RarityChoiceItem(RareDecision());
    }

    //==================================================
    //���A�x�������A�C�e���̒����烉���_���Ō��߂�B
    //==================================================
    private void RarityChoiceItem(Item.ITEMRATE itemrate)
    {
        //GameObject obj;
        int idx = 0;
        switch (itemrate)
        {
            case Item.ITEMRATE.NORMAL:
                //�����_��
                idx = Random.Range(0, normalItem.Length);
                if (isOnline)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        respawnItem = (GameObject)PhotonNetwork.InstantiateRoomObject("Item/"+normalItem[idx].name, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                        //respawnItem.transform.parent = transform;
                    }
                }
                else
                {
                    respawnItem = (GameObject)Instantiate(normalItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    //respawnItem.transform.parent = transform;
                }
                Debug.Log("NORMAL");
                break;
            case Item.ITEMRATE.RARE:
                idx = Random.Range(0, rareItem.Length);
                if (isOnline)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        respawnItem = (GameObject)PhotonNetwork.InstantiateRoomObject("Item/" + rareItem[idx].name, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                        //respawnItem.transform.parent = transform;
                    }
                }
                else
                {
                    respawnItem = (GameObject)Instantiate(rareItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    //respawnItem.transform.parent = transform;
                }
                Debug.Log("RARE");
                break;
            case Item.ITEMRATE.SR:
                idx = Random.Range(0, superItem.Length);
                if (isOnline)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        respawnItem = (GameObject)PhotonNetwork.InstantiateRoomObject("Item/" + superItem[idx].name, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                        //respawnItem.transform.parent = transform;
                    }
                }
                else
                {
                    respawnItem = (GameObject)Instantiate(superItem[idx], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    //obj.transform.parent = transform;
                }
                Debug.Log("SR");
                break;
            default:
                break;
        }
    }
    //�m�����Y��ɂ���B
    private void AverageRate()
    {
        for (int i = 0; i < popRate.Length; i++)
        {
            popNum += popRate[i];
        }
        for (int i = 0; i < popRate.Length; i++)
        {
            popRate[i] = (popRate[i] / popNum) * 100;
        }

        Debug.Log(popRate[0]);
        Debug.Log(popRate[1]);
        Debug.Log(popRate[2]);
    }

    //�o�������郌�A�x���m�肳����
    Item.ITEMRATE RareDecision()
    {

        float cnt = Random.Range(0f, popNum);
        for (int i = 0; i < popRate.Length; i++)
        {
            if (popRate[i] < cnt)//��r����
            {
                cnt -= popRate[i];
            }
            else
            {
                return (Item.ITEMRATE)i;//���A�x���m�肳����
            }
        }

        Debug.Log("�ʂ��Ă͂����Ȃ����[�g:ItemBoxManager");
        return Item.ITEMRATE.NORMAL;
    }





    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            m_isHitOther = true;
            Debug.Log("�v���C���[�ȊO�̉����ɓ������Ă���");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            Debug.Log("�v���C���[�ȊO�̉��������ꂽ");
            m_isHitOther = false;
        }
    }

}
