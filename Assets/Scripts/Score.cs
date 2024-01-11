using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private static int highScore = 0;

    private int coefficient = 100;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    // Singleton
    public static Score Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.parent);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", highScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float newScore = Time.deltaTime * coefficient;
        score += Mathf.RoundToInt(newScore);
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
        }
        AddScore(score);     
    }

    private void AddScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void ResetScore()
    {
        score = 0;
    }
}
