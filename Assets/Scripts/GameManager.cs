using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject easyCards;
    public GameObject mediumCards;
    public GameObject hardCards;

    public GameObject[] cards;
    public List<GameObject> gameObjects;

    public bool isMediumCardsActive;
    public bool isHardCardsActive;

    public int numberOfObjects = 6;

    public static string flippedCardName = "";

    private void Start()
    {
        easyCards.SetActive(true);

        if (isHardCardsActive)
        {
            numberOfObjects += 6;

            hardCards.SetActive(true);

            isMediumCardsActive = true;
        }

        if (isMediumCardsActive)
        {
            numberOfObjects += 6;

            mediumCards.SetActive(true);
        }

        int randomInt = Random.Range(0, numberOfObjects);
        int cardsLeft = numberOfObjects;
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject card = Instantiate(gameObjects[randomInt], cards[i].transform);
            gameObjects.Remove(gameObjects[randomInt]);
            cardsLeft -= 1;
            randomInt = Random.Range(0, cardsLeft);
        }
        Debug.Log("Number of objects: " + numberOfObjects);
    }
}
