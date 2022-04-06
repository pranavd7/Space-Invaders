using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] UIManager uiManager;

    int score;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        uiManager.InitializeHealth((int)playerHealth.maxHealth);
        uiManager.InitializeScore();

        playerHealth.OnDamageEvent += uiManager.RefreshHealthUI;
        playerHealth.OnIncreaseHealthEvent += uiManager.RefreshHealthUI;
    }

    /// <summary>
    /// Load a scene using the scene name
    /// </summary>
    /// <param name="level"></param>
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Load a scene using the scene build index
    /// </summary>
    /// <param name="level"></param>
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
