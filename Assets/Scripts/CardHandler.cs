using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    Animator animator;
    bool isFlipped = false;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse down on"+gameObject.name);
        isFlipped = !isFlipped;
        if (isFlipped)
        {
            animator.SetTrigger("IsFlipped");
            if (gameObject.name == GameManager.flippedCardName)
            {
                Debug.Log("Card matched: " + gameObject.name);
            }
            GameManager.flippedCardName = gameObject.name;
        }
        else
        {
            animator.SetTrigger("IsBack");
        }
        
    }
}
