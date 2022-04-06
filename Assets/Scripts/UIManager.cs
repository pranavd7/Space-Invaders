using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject heartPf;
    [SerializeField] GameObject HealthParentObj;

    [SerializeField] TMP_Text scoreText;

    GameObject[] hearts;

    /// <summary>
    /// Initialize the number of hearts for player
    /// </summary>
    /// <param name="maxHealth"></param>
    public void InitializeHealth(int maxHealth)
    {
        hearts = new GameObject[maxHealth];
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i] = Instantiate(heartPf, transform);
        }
    }

    /// <summary>
    /// Initialize score text to 0
    /// </summary>
    public void InitializeScore()
    {
        scoreText.text = "Score: 0";
    }

    /// <summary>
    /// Refresh the number of hearts visible according to current health
    /// </summary>
    /// <param name="health"></param>
    public void RefreshHealthUI(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Refresh score text according to current score
    /// </summary>
    /// <param name="score"></param>
    public void RefreshScoreUI(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
