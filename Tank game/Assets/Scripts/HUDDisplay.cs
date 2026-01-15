using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDDisplay : MonoBehaviour
{
    [Header("Referencje do UI (Przeciągnij z Hierarchii)")]
    public Text healthText;
    public Text pointsText;
    public Text comboText;
    public Text enemyCountText;

    private Health playerHealth;
    private PointTracker playerPoints;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 0 || currentScene.name == "MainMenu")
        {
            gameObject.SetActive(false);
            return;
        }

        GameObject player = GameObject.Find("Player");
        
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
            playerPoints = player.GetComponent<PointTracker>();
        }
    }

    void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        if (healthText != null)
        {
            if (playerHealth != null)
            {
                int currentHP = playerHealth.GetCurrentHealth();
                healthText.text = "HP: " + currentHP + " / " + playerHealth.maxHealth;
            }
            else
            {
                healthText.text = "HP: 0 / 3";
            }
        }

        if (playerPoints != null)
        {
            if (pointsText != null) pointsText.text = "Punkty: " + playerPoints.points;
            if (comboText != null) comboText.text = "Combo: x" + playerPoints.combo;
        }

        if (enemyCountText != null)
        {
            int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
            enemyCountText.text = "Wrogowie: " + (enemiesLeft / 2);
        }
    }
}
