using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameObject heroTeamA;
    [SerializeField] GameObject heroTeamB;
    public GameObject backGround;
    public TextMeshProUGUI gameOverText;

    private void Update()
    {
        ApplyEndGameScreen();
    }

    private void ApplyEndGameScreen()
    {
        backGround.SetActive(false);

        if (heroTeamA == null)
        {
            backGround.SetActive(true);
            Time.timeScale = 0;
            gameOverText.text = "You Lose";
        }
        else if (heroTeamB == null)
        {
            backGround.SetActive(true);
            Time.timeScale = 0;
            gameOverText.text = "You Win";
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
