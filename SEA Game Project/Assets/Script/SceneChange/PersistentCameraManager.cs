using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentCameraManager : MonoBehaviour
{
    public GameObject camera1; 
    public GameObject camera2;
    public GameObject Shops;

    private void Awake()
    {
        // Buat agar tidak dihancurkan antar scene
        DontDestroyOnLoad(gameObject);

        // Subscribe ke event scene change
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Penting! Unsubscribe agar tidak error
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        if (sceneName == "RPG")
        {
            if (camera1 != null) camera1.SetActive(true);
            if (camera2 != null) camera2.SetActive(false);
            if (Shops != null) Shops.SetActive(false);
        }
        else if (sceneName == "RPG 2")
        {
            if (camera1 != null) camera1.SetActive(false);
            if (camera2 != null) camera2.SetActive(true);
            if (Shops != null) Shops.SetActive(true);
        }
    }
}
