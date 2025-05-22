using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
    {
        // Variables
        public GameOverScreen GameOverScreen;
        public int maxPlatform = 0;

        // Method to trigger Game Over screen
        public void GameOver(int score)
        {
            GameOverScreen.Setup(score);
        }
    }


