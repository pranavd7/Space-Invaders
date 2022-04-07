using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] UIManager uiManager;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] GameObject endScreen;
    [SerializeField] TMPro.TMP_Text endScreenText;

    int score;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        endScreen.SetActive(false);

        uiManager.InitializeHealth((int)playerHealth.maxHealth);
        uiManager.InitializeScore();

        playerHealth.OnDamageEvent += uiManager.RefreshHealthUI;
        playerHealth.OnIncreaseHealthEvent += uiManager.RefreshHealthUI;
        playerHealth.OnDeathEvent += ShowGameOverScreen;

        enemyManager.OnEnemyDeath += () => uiManager.RefreshScoreUI(++score);
        enemyManager.OnAllEnemiesDead += ShowLevelCompletedScreen;
    }

    void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        endScreenText.text = "GAME OVER";
        endScreen.SetActive(true);
    }
    void ShowLevelCompletedScreen()
    {
        Time.timeScale = 0;
        endScreenText.text = "Level Completed!";
        endScreen.SetActive(true);
    }

    /// <summary>
    /// Load a scene using the scene name
    /// </summary>
    /// <param name="level"></param>
    public void LoadLevel(string level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Load a scene using the scene build index
    /// </summary>
    /// <param name="level"></param>
    public void LoadLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Reload current scene
    /// </summary>
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Close the game
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
