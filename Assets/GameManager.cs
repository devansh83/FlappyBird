using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverCanvas;

    public GameObject medals;
    public GameObject pauseMenu;

    public TextMeshProUGUI currentscoreText;
    public AudioSource audioSource;
    public AudioSource pauseAudioSource;
    bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
            pauseMenu.SetActive(isPaused);
            if (isPaused)
            {
                audioSource.Pause();
                //play a short sound effect for pause
                pauseAudioSource.Play();
            }
            else
            {
                audioSource.Play();
            }
        }

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        audioSource.Stop();
        int finalScore = int.Parse(currentscoreText.text);
        if (finalScore >= 10)
        {
            medals.transform.GetChild(2).gameObject.SetActive(true); // Assuming Gold is the third child
        }
        else if (finalScore >= 5)
        {
            medals.transform.GetChild(1).gameObject.SetActive(true); // Assuming Silver is the second child
        }
        else if (finalScore >= 1)
        {
            medals.transform.GetChild(0).gameObject.SetActive(true); // Assuming Bronze is the first child
        }
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
