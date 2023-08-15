using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextDisplayController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public int score =0;

    private void OnEnable()
    {
        PlayerController.onIncrementScore += OnIncrementScore;
        PlayerController.onHitTheWall += OnHitTheWall;
        SetScore(0);
        gameOverText.gameObject.SetActive(false);
    }

    public void OnGameOver()
    {

    }

    public void OnIncrementScore()
    {
        SetScore(this.score += 10);
    }


    void SetScore( int score)
    {
        this.score = score;
        scoreText.text = "Score: " + this.score.ToString();
    }

    void OnHitTheWall()
    {
        gameOverText.gameObject.SetActive(true);
        // Pause the game   
        Time.timeScale = 0;
    }

}
