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
        topScoreText.text = "Top Score: " + MenuManager.Instance.topScore;
    }

    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
