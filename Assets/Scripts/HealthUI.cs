using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject heartPf;

    GameObject[] hearts;

    public void Initialize(int maxHealth)
    {
        hearts = new GameObject[maxHealth];
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i] = Instantiate(heartPf, transform);
        }
    }

    public void RefreshUI(int health)
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
}
