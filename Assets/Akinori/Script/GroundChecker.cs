using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GroundChecker : MonoBehaviour
{
    //Ú’n‚µ‚½ê‡‚Ìˆ—
    public UnityEvent OnEnterGround;
    //’n–Ê‚©‚ç—£‚ê‚½ê‡‚Ìˆ—
    public UnityEvent OnExitGround;
    //Ú’n”
    private int enterNum = 0;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnGround!");
        enterNum++;
        OnEnterGround.Invoke();
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("ExitGround!");
        enterNum--;
        if (enterNum <= 0)
        {
            OnExitGround.Invoke();
        }
    }
}
