using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI currentscoreText;
    public TextMeshProUGUI highscoreText;
    public int score = 0;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        currentscoreText.text = score.ToString();
        highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }
    public void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreText.text = score.ToString();
        }
    }
    public void updateScore()
    {
        score++;
        currentscoreText.text = score.ToString();
        UpdateHighScore();
    }
}
