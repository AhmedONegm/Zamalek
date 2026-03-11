using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse down on GameManager");
        animator.SetBool("IsSelected", true);
    }
}
