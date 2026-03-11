using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void MediumLevel()
    {
        GameManager.Instance.isMediumCardsActive = true;
        startGame();
    }

    public void HardLevel()
    {
        GameManager.Instance.isHardCardsActive = true;
        startGame();
    }
}
