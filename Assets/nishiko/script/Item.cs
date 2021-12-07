using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Item : MonoBehaviour
{
    //�d��
    [Header("�o�₷��(������)")]
    [SerializeField]
    private int myWeight = 0;

     public enum ITEMRATE
    {
        NORMAL,
        RARE,
        SR
    }

    public ITEMRATE enumRate;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetWeight()
    {
        return myWeight;
    }

    public void addWeight(int wht)
    {
        myWeight += wht;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("�A�C�e���擾");
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                Debug.Log("�I�t���C��");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�A�C�e���擾");
            if (PhotonNetwork.IsConnected)
            {
                transform.parent = other.transform;
               // PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                Debug.Log("�I�t���C��");
                Destroy(gameObject);
            }
        }
    }
}
