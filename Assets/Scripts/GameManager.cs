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

    public List<GameObject> gameObjects;

    public bool isMediumCardsActive;
    public bool isHardCardsActive;

    public int numberOfObjects = 6;

    private void Start()
    {
        easyCards.SetActive(true);
        int randomInt = Random.Range(0, numberOfObjects);

        for (int i = 0; i<easyCards.transform.childCount; i++)
        {
            easyCards.transform.GetChild(i);
            GameObject instantiatedChild = Instantiate(gameObjects[randomInt], easyCards.transform.GetChild(i));
            gameObjects.RemoveAt(randomInt);
        }

        if (isHardCardsActive)
        {
            numberOfObjects += 6;

            hardCards.SetActive(true);

            isMediumCardsActive = true;

            foreach (Transform child in hardCards.transform)
            {
            }
        }

        if (isMediumCardsActive)
        {
            numberOfObjects += 6;

            mediumCards.SetActive(true);

            foreach (Transform child in mediumCards.transform)
            {
            }
        }
        Debug.Log("Number of objects: " + numberOfObjects);
    }
}
