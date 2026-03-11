using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    Renderer renderer;
    Animator animator;
    private void Awake()
    {
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse down on GameManager");
        renderer.materials[1]= GameManager.Instance.cardBackMaterial;
        animator.SetBool("isFlipped", true);
    }
}
