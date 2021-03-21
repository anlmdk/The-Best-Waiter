using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Static bools for game action
    public static bool gameIsStarted, gameIsOver, nextLevelCheck;

    // Canvas panels
    public GameObject swipeText, gamePanel, gameOverPanel, nextLevelPanel;

    // Text for money and order Percent
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI orderPercentText;

    // We have static order and money variable when start the game
    public static int order = 0, money = 0;

    void Start()
    {
        gameIsStarted = false;
        gameIsOver = false;
        nextLevelCheck = false;
        swipeText.SetActive(true);
        nextLevelPanel.SetActive(false);
        Time.timeScale = 1f;
        order = 0; // Give order equals 0 cause when game retry or next level, the game saved the last percent
    }
    void Update()
    {
        moneyText.text = money.ToString();
        orderPercentText.text = "% " + order;

        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
        if (gameIsOver == true)
        {
            GameOver();
        }
        if (nextLevelCheck == true)
        {
            NextLevel();
        }
    }
    // When press on the screen game will start
    void StartGame()
    {
        gameIsStarted = true;
        swipeText.SetActive(false);
    }
    // When game over is true 
    void GameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    // If player get % 70 order
    void NextLevel()
    {
        gamePanel.SetActive(false);
        nextLevelPanel.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerController>().ForwardSpeed = 0f;
        GameObject.Find("Player").GetComponent<PlayerController>().SwipeSpeed = 0f;
        GameObject.Find("Player").GetComponent<PlayerController>().Jump = 0f;
    }
}

