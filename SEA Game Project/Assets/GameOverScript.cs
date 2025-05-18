using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("RPG");
    }

    public void ExitButton()
    {
        // Menutup aplikasi
        Application.Quit();
    }
}
