using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Persistent Objects")]

    public GameObject[] persistentObjects;
    public GameObject gameOverUI;


    private void Awake()
    {
        if(instance != null)
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    private void MarkPersistentObjects()
    {
        foreach(GameObject obj in persistentObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad (obj); 
            }
        }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }

        Destroy(gameObject);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
}
