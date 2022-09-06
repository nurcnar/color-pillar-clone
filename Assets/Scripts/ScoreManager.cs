using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscore;
    public int score;
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();

    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " +score.ToString();
    }
    public void DecreaseScore()
    {
        score--;
        score = Mathf.Clamp(score, 0, score);
        scoreText.text = "Score: " + score.ToString();
    }
    private void OnDestroy()
    {
        SaveHighScore();
    }
    private void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscore.text = "Highscore: " + score.ToString();
        }
        PlayerPrefs.Save();
    }
}
