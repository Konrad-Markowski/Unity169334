using UnityEngine;
using UnityEngine.UI;

namespace TankGame
{
    public class EndScreenDisplay : MonoBehaviour
    {
        [Header("Panel Końcowy - Przeciągnij obiekty z EndScreen")]
        public GameObject endPanel;
        public Text levelFinishedText;
        public Text yourScoreText;
        public Text bestScoreText;

        private bool gameEnded = false;
        private GameObject playerRef;

        void Start()
        {
            playerRef = GameObject.Find("Player");

            if (playerRef == null)
            {
                Debug.LogWarning("Uwaga: Nie znaleziono gracza na starcie sceny!");
            }

            endPanel?.SetActive(false);
        }

        void Update()
        {
            if (gameEnded) return;

            CheckGameStatus();
        }

        void CheckGameStatus()
        {
            if (playerRef == null)
            {
                GameOver(false);
                return;
            }

            int enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemiesCount == 0)
            {
                GameOver(true);
            }
        }

        void GameOver(bool win)
        {
            gameEnded = true;

            endPanel?.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (win)
            {
                if (levelFinishedText != null) levelFinishedText.text = "POZIOM UKOŃCZONY!";

                if (playerRef != null)
                {
                    PointTracker tracker = playerRef.GetComponent<PointTracker>();
                    if (tracker != null)
                    {
                        tracker.CheckAndSaveHighScore();
                        if (yourScoreText != null) yourScoreText.text = "Twój wynik: " + tracker.points;
                        if (bestScoreText != null) bestScoreText.text = "Najlepszy wynik: " + tracker.bestScore;
                    }
                }
            }
            else
            {
                if (levelFinishedText != null) levelFinishedText.text = "ZOSTAŁEŚ ZNISZCZONY!";
                if (yourScoreText != null) yourScoreText.text = "Twój wynik: 0";

                int savedBestScore = PlayerPrefs.GetInt("BestScore", 0);
                if (bestScoreText != null) bestScoreText.text = "Najlepszy wynik: " + savedBestScore;
            }
        }

        public void RestartLevel()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
