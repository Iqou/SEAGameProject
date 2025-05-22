using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI;


    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
    
    public void ExitButton()
    {
        // Menutup aplikasi
        Application.Quit();
    }
}
