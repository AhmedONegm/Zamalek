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

    public static bool isMediumCardsActive;
    public static bool isHardCardsActive;

    public int numberOfObjects = 6;

    public GameObject flippedCard1;
    public GameObject flippedCard2;

    public int score = 0;
    
    public int flippedCardsCount = 0;

    [SerializeField] private AudioSource audioSource;
    
    public AudioClip flipSound;
    public AudioClip matchSound;
    public AudioClip errorSound;
    public AudioClip winSound;

    [SerializeField] private TMPro.TextMeshProUGUI scoreUI;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void UpdateScoreUI()
    {
        scoreUI.text = "Score: " + score;
    }
}
