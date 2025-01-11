using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowColors : MonoBehaviour
{
    private Animator animator;
    private bool isShow = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    public void showInvent()
    {
        if (isShow == false)
        {
            animator.SetTrigger("show");
            isShow = true;
        }
        else
        {
            animator.SetTrigger("hide");
            isShow = false;
        }

    }


}
