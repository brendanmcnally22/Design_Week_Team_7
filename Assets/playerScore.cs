using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {

        UpdateScoreText();

    }

    // Update is called once per frame
    public void AddScore(int points)
    {


        score += points;
        if (scoreText!= null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        
    }
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }

    }
}
