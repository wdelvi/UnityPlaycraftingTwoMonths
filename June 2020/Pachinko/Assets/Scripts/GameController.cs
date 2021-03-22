using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject endGameScreen;
    public Text ballsText;
    public Text endGameScoreText;
    public Text endGameHighScoreText;
    public int startingBalls = 10;
    private int currentBalls;

    private PrefabSpawner prefabSpawner;
    private ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        currentBalls = startingBalls;
        prefabSpawner = gameObject.GetComponent<PrefabSpawner>();
        scoreKeeper = gameObject.GetComponent<ScoreKeeper>();
        ballsText.text = "BALLS: " + currentBalls;
    }

    public void SpawnBall()
    {
        if (currentBalls > 0)
        {
            prefabSpawner.SpawnPrefab();
            currentBalls--;
            ballsText.text = "BALLS: " + currentBalls;
        }
        else
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        endGameScoreText.text = "YOUR SCORE: " + scoreKeeper.score;
        endGameHighScoreText.text = "HIGH SCORE: " + scoreKeeper.highScore;

        endGameScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
