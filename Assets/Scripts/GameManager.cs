using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Text gameStatusText;
    [SerializeField] private int totalEnemies;
    [SerializeField] GameObject restart_button;
    private int enemiesKilled = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        CheckGameStatus();
    }

    void CheckGameStatus()
    {
        if (enemiesKilled >= totalEnemies)
        {
            Victory();
        }
    }

    void Victory()
    {
        restart_button.SetActive(true);
        gameStatusText.text = "You Win!";
        Time.timeScale = 0;
    }

    public void PlayerDied()
    {
        restart_button.SetActive(true);
        gameStatusText.text = "You Lose!";
        Time.timeScale = 0;
    }
}
