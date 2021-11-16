using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponFrame;
    [SerializeField]
    private GameObject aimPos;
    [SerializeField]
    private GameObject weaponInitPos;
    [SerializeField]
    private float aimSpeed;

    public bool isWquip;


    private IPlayerAction equippedWeaponAction;
    // Update is called once per frame

    private void Start()
    {
        //aimPos.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
        weaponInitPos.transform.position = weaponFrame.transform.position;
    }
    void Update()
    {
        if (this.transform.GetChild(0) != null)
        {
            isWquip = true;
        }
        if (isWquip)
        {

            if (Input.GetMouseButton(0))
            {
                if (weaponFrame.transform.childCount > 0)
                {
                    equippedWeaponAction.InPlayerAction();
                }
            }
            if (Input.GetMouseButton(1))
            {
                //print("右ボタンが押されている");

                weaponFrame.transform.position = Vector3.Slerp(weaponFrame.transform.position, aimPos.transform.position, aimSpeed);
            }
            else
            {

                weaponFrame.transform.position = Vector3.Slerp(weaponFrame.transform.position, weaponInitPos.transform.position,aimSpeed);

            }
        }
        if (Input.GetMouseButton(2))
        {
            //print("中ボタンが押されている");
        }
        if (weaponFrame.transform.childCount > 0)
        {
            weaponFrame.transform.GetChild(0).transform.localPosition = Vector3.zero;
            weaponFrame.transform.GetChild(0).transform.localEulerAngles = Vector3.zero;
        }

    }

    public void EquipWeapon(GameObject _weapon)
    {
        if (weaponFrame.transform.childCount == 0)
        {
            _weapon.transform.parent = weaponFrame.transform;

            //_weapon.transform.position = Vector3.zero;
            //_weapon.transform.eulerAngles = Vector3.zero;

            equippedWeaponAction = _weapon.GetComponent<IPlayerAction>();
        }
    }
}
//RpcShot

//CallShot