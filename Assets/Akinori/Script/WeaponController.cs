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
                //weaponFrame.transform.GetChild(0).GetComponent<IPlayerAction>().InPlayerAction();
                equippedWeaponAction.InPlayerAction();
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

        
    }

    public void EquipWeapon(GameObject _weapon)
    {
        _weapon.transform.parent = weaponFrame.transform;

        equippedWeaponAction = _weapon.GetComponent<IPlayerAction>();
    }
}
//RpcShot

//CallShot