using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    public static Manager Instance { get { return _instance; } }

    private int score = 0;
    private int streakMultiplier = 1;
    private Color currentStreakColor = Color.black;

    public Image streakImage;
    public Text streakMultiplierText;
    public Text scoreText;

    public GameObject topPanel;
    public GameObject endGamePanel;
    public Text curerntScoreText;

    [HideInInspector] public bool gameOver = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        scoreText.text = "Score:\n0";
        streakMultiplierText.text = "x1";
        streakImage.color = Color.black;

        topPanel.SetActive(true);
        endGamePanel.SetActive(false);
    }

    public void UpdateScore(Food food)
    {
        score += (streakMultiplier * food.points);
        if (currentStreakColor == food.color)
        {
            streakMultiplier++;
        }
        else
        {
            streakMultiplier = 1;
        }
        currentStreakColor = food.color;

        scoreText.text = "Score:\n" + score;
        streakMultiplierText.text = "x" + streakMultiplier;
        streakImage.color = currentStreakColor;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if (gameOver)
        {
            topPanel.SetActive(false);
            endGamePanel.SetActive(true);
            curerntScoreText.text = "Current Score: " + score;

            if (score >= PlayerPrefs.GetInt("TopScore", 0))
            {
                PlayerPrefs.SetInt("TopScore", score);
            }
        }
    }
}
