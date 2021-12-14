using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PotalCreate : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject potal;

    enum PotalCreateMode
    {
        IsEnableCreate,
        CreateStartPoint,
        CreateEndPoint,
        NotEnableCreate,
    }
    PotalCreateMode createMode = PotalCreateMode.IsEnableCreate;
    // Start is called before the first frame update
    void Start()
    {
        //potal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        switch (createMode)
        {
            case PotalCreateMode.IsEnableCreate:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //potal = new GameObject();
                    Instantiate( potal, this.transform.position, this.transform.rotation);
                    //potal.AddComponent<Potal>();
                    potal.SetActive(true);
                    createMode = PotalCreateMode.CreateStartPoint;
                    Debug.Log(createMode);
                }
                break;
            case PotalCreateMode.CreateStartPoint:
                //メインカメラ上のマウスポインタのある位置からrayを飛ばす
               
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(ray, out hit, Mathf.Infinity);
                    if (hit.collider.gameObject.tag == "PotalWall")
                    {
                        potal.transform.GetComponent<Potal>().SetStartPoint(hit.transform.position);
                        Debug.Log(hit.collider.gameObject.name);

                        Debug.Log("StartPoint : " + hit.transform.position);
                        createMode = PotalCreateMode.CreateEndPoint;
                        Debug.Log(createMode);
                    }
                }
                break;
            case PotalCreateMode.CreateEndPoint:
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(ray, out hit, Mathf.Infinity);
                    if (hit.collider.gameObject.tag == "PotalWall")
                    {
                        potal.transform.GetComponent<Potal>().SetEndPoint(hit.transform.position);
                        Debug.Log(hit.collider.gameObject.name);
                        Debug.Log("EndPoint : " + hit.transform.position);
                        createMode = PotalCreateMode.NotEnableCreate;
                        Debug.Log(createMode);
                        potal.SetActive(true);
                    }
                }
                break;
            case PotalCreateMode.NotEnableCreate:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    createMode = PotalCreateMode.IsEnableCreate;
                    Debug.Log(createMode);
                }
                break;
            default:
                break;
        }
        

    }
}
