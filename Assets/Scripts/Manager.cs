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

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        scoreText.text = "0";
        streakMultiplierText.text = "x1";
        streakImage.color = Color.black;
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

        scoreText.text = "" + score;
        streakMultiplierText.text = "x" + streakMultiplier;
        streakImage.color = currentStreakColor;
    }

    public void GameOver()
    {
        if (score >= MenuManager.Instance.topScore)
        {
            MenuManager.Instance.topScore = score;
        }
        SceneManager.LoadScene("Menu");
    }
}
