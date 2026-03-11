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
            GameManager.Instance.PlayFlipSound();
            if (gameObject.name == GameManager.Instance.flippedCardName)
            {
                Debug.Log("Card matched: " + gameObject.name);
                GameManager.Instance.score++;
                GameManager.Instance.UpdateScoreUI();
                if (GameManager.Instance.score == GameManager.Instance.numberOfObjects / 2)
                {
                    Debug.Log("All cards matched! Score: " + GameManager.Instance.score);
                }
            }
            GameManager.Instance.flippedCardName = gameObject.name;
        }
        else
        {
            animator.SetTrigger("IsBack");
            GameManager.Instance.PlayFlipSound();
        }
    }
}
