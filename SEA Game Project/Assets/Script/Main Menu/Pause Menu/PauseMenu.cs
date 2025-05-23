using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.setActive(true);
        // Pause the game when the script starts
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.setActive(false);
        // Resume the game when the script starts
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // Quit the game when the script starts
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void MainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }


}
