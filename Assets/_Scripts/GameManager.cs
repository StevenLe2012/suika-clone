using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int CurrentScore { get; set; } = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image gameOverPanel;
    [SerializeField] private float fadeTime = 2f;

    public float TimeTillGameOver = 1.5f;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scoreText.text = CurrentScore.ToString("0");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += FadeGame;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FadeGame;
    }

    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        scoreText.text = CurrentScore.ToString("0");
    }
    
    public void GameOver()
    {
        StartCoroutine(ResetGame());
    }

    private IEnumerator ResetGame()
    {
        gameOverPanel.gameObject.SetActive(true);
        
        Color startColor = gameOverPanel.color;
        startColor.a = 0f;
        gameOverPanel.color = startColor;
        
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            startColor.a = newAlpha;
            gameOverPanel.color = startColor;
            yield return null;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void FadeGame(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeGameIn());
    }

    private IEnumerator FadeGameIn()
    {
        gameOverPanel.gameObject.SetActive(true);
        Color startColor = gameOverPanel.color;
        startColor.a = 1f;
        gameOverPanel.color = startColor;
        
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime);
            startColor.a = newAlpha;
            gameOverPanel.color = startColor;
            yield return null;
        }
        
        gameOverPanel.gameObject.SetActive(false);
    }
}
