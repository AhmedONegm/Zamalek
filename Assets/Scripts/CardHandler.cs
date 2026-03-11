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
            animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down on " + gameObject.name);

        if (isFlipped) return;

        isFlipped = true;
        animator.SetTrigger("IsFlipped");
        GameManager.Instance.PlaySound(GameManager.Instance.flipSound);

        GameManager.Instance.flippedCardsCount++;

        if (GameManager.Instance.flippedCardsCount == 1)
        {
            GameManager.Instance.flippedCard1 = gameObject;
        }
        else if (GameManager.Instance.flippedCardsCount == 2)
        {
            GameManager.Instance.flippedCard2 = gameObject;

            if (GameManager.Instance.flippedCard1.name == GameManager.Instance.flippedCard2.name)
            {
                Debug.Log("Card matched!");

                GameManager.Instance.PlaySound(GameManager.Instance.matchSound);

                GameManager.Instance.score++;
                GameManager.Instance.UpdateScoreUI();

                GameManager.Instance.flippedCardsCount = 0;
            }
            else
            {
                Debug.Log("Too many cards flipped! Resetting.");
                Invoke("ResetFlippedCards", 1f);
            }

            if (GameManager.Instance.score == GameManager.Instance.numberOfObjects / 2)
            {
                Debug.Log("All cards matched! Score: " + GameManager.Instance.score);
                GameManager.Instance.PlaySound(GameManager.Instance.winSound);
            }
        }
    }
    void ResetFlippedCards()
    {
        GameManager.Instance.flippedCardsCount = 0;

        GameManager.Instance.flippedCard1.GetComponent<CardHandler>().animator.SetTrigger("IsBack");
        GameManager.Instance.flippedCard2.GetComponent<CardHandler>().animator.SetTrigger("IsBack");

        GameManager.Instance.flippedCard1.GetComponent<CardHandler>().isFlipped = false;
        GameManager.Instance.flippedCard2.GetComponent<CardHandler>().isFlipped = false;

        Debug.Log("Flipped cards reset.");
    }

}