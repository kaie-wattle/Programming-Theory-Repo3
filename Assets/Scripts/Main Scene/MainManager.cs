using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button titleButton;
    public bool isGameActive;
    [SerializeField] GameObject player;
    [SerializeField] int setLife;
    [SerializeField] float setGameTime;
    private int life;
    private int score;
    private float gameTime;

    private void Awake()
    {
        GameStart();
    }
    private void Update()
    {
        if (isGameActive)
        {
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        gameTime -= Time.deltaTime;
        timeText.SetText("TIME:" + Mathf.Round(gameTime));
        if (gameTime <= 0f)
        {
            GameOver();
        }
    }

    public void UpdateLife(int sub)
    {
        life -= sub;
        lifeText.SetText("LIFE:" + life);
        if (life <= 0)
        {
            GameOver();
        }
    }

    public void UpdateScore(int add)
    {
        score += add;
        scoreText.SetText("SCORE:" + score);
    }

    public void GameOver()
    {
        Destroy(player);
        restartButton.gameObject.SetActive(true);
        titleButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        GameManager.instance.SetScore(score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    private void GameStart()
    {
        isGameActive = true;
        life = setLife;
        score = 0;
        gameTime = setGameTime;

        UpdateLife(0);
        UpdateScore(0);
    }
}
