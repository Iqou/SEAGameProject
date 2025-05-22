using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static class GameData
    {
        public static bool retryFromGameOver = false;
    }


    public void RetryLevel()
    {
        GameData.retryFromGameOver = true;
        SceneManager.LoadScene("RPG1"); // or GetActiveScene().name if retrying current level
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
