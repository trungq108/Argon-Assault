using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    int score;

    public void IncreasetScore(int ScoreAdded)
    {
        score += ScoreAdded;
        scoreText.text = "Score: " + score.ToString();
    }
}
