using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // You can load by build index or scene name
        SceneManager.LoadScene("RPG"); // Replace with your actual scene name
    }
    public void QuitGame()
    {
        // This will quit the application
        // Note: This won't work in the editor, but will work in a built application
        // Application.Quit();

        // If you want to stop playing in the editor, uncomment the line below
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    

}
