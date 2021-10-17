using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;

    private const string key_isRun = "isRun";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            this.animator.SetBool(key_isRun, true);
        }
        else
        {
            this.animator.SetBool(key_isRun, false);
        }
    }
}
