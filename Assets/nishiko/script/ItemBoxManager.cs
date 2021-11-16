using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxManager : MonoBehaviour
{
    [Header("�����Ԋu(�b��)")]
    [SerializeField] private int m_interval = 30;

    //�J�n���b�܂ł̓��A�A�C�e�����o���Ȃ��悤�ɂ���
    private int NonrareSeconds = 30;
    private bool timeOverNonrare = true;



    [Header("�A�C�e���{�b�N�X")]
    [SerializeField]
    private ItemBox[] m_objItembox;

    [Header("�A�C�e���{�b�N�X(��)")]
    [SerializeField]
    private int m_MaxNum=0;

    float m_myTime;//�o�ߎ���


    //�m���m�F�p
    float compRate;

    [Header("���ꂼ��̊m��(�ォ�烌�A�x���Ⴂ)")]
    public float[] popRate = new float[3];
    private float[] saveRate = new float[3];    //�ۑ��pRate
    private float popNum;


    


    // Start is called before the first frame update
    void Start()
    {
        m_MaxNum = m_objItembox.Length; //�A�C�e���{�b�N�X�̍ő吔���m��
        AverageRate(); //�m�����Y��ɂ���B

        for (int i = 0; i < popRate.Length; i++)
        {
            saveRate[i] = popRate[i];   //�ۑ�����B
        }

    }

    // Update is called once per frame
    void Update()
    {
        m_myTime += Time.deltaTime;//���Ԃ��o�߂�����
        int second = (int)m_myTime % 60;


        if (second > NonrareSeconds && timeOverNonrare)//�w��̎��Ԃ��߂����烌�A�A�C�e���o���\�ɂ���
        {
            timeOverNonrare = false;
            popRate[2] = saveRate[2];
            AverageRate();
        }








    }

    ////�m�����Y��ɂ���B
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

    ////�o�������郌�A�x���m�肳����
    //Item.ITEMRATE RareDecision()
    //{

    //    float cnt = Random.Range(0f, popNum);
    //    for (int i = 0; i < popRate.Length; i++)
    //    {
    //        if (popRate[i] < cnt)//��r����
    //        {
    //            cnt -= popRate[i];
    //        }
    //        else
    //        {
    //            return (Item.ITEMRATE)i;//���A�x���m�肳����
    //        }
    //    }

    //    Debug.Log("�ʂ��Ă͂����Ȃ����[�g:ItemBoxManager");
    //    return Item.ITEMRATE.NORMAL;
    //}



}
