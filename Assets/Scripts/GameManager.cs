using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] HealthUI healthUI;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        healthUI.Initialize((int)playerHealth.maxHealth);

        playerHealth.OnDamageEvent += healthUI.RefreshUI;
        playerHealth.OnIncreaseHealthEvent += healthUI.RefreshUI;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
