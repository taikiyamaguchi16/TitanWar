using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    Collider[] attackCols;

    [SerializeField]
    bool activeWhenStart = true;

    [SerializeField]
    float attackPower = 10f;

    public float AttackPower { get { return attackPower; } private set { attackPower = value; } }

    // Start is called before the first frame update
    void Start()
    {
        if (activeWhenStart)
        {
            foreach (Collider col in attackCols)
            {
                col.enabled = true;
            }
        }
        else
        {
            foreach (Collider col in attackCols)
            {
                col.enabled = false;
            }
        }
    }

    public void AttackActive(bool _active)
    {
        foreach (Collider col in attackCols)
        {
            col.enabled = _active;
        }
    }
}
