using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour
{
    Animator animator;

    public float horizontal;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontal != 0)
        {
            animator.SetBool("isRunning", true);
            animator.SetFloat("Horizontal", horizontal);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
