using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public Text topScoreText;

    private void Start()
    {
        if (topScoreText == null)
        {
            topScoreText = GameObject.Find("UI/Panel/Top Score").GetComponent<Text>();
        }
        int topScore = PlayerPrefs.GetInt("TopScore", 0);
        topScoreText.text = "Top Score: " + topScore;
    }

    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
