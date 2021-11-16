using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponFrame;
    public bool isWquip;

    private IPlayerAction equippedWeaponAction;
    // Update is called once per frame
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
        _weapon.transform.parent = weaponFrame.transform;

        //_weapon.transform.position = Vector3.zero;
        //_weapon.transform.eulerAngles = Vector3.zero;

        equippedWeaponAction = _weapon.GetComponent<IPlayerAction>();
    }
}
//RpcShot

//CallShot