using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthslider;
    private bool isdead;
    public GameManager gameManager;

    void Start()
    {
        StatsManager.instance.currentHealth = StatsManager.instance.maxHealth;
        healthslider.maxValue = StatsManager.instance.maxHealth;
        healthslider.value = StatsManager.instance.currentHealth;
    }

    public void Update()
    {
        healthslider.value = StatsManager.instance.currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        StatsManager.instance.currentHealth += amount;
        StatsManager.instance.currentHealth = Mathf.Clamp(StatsManager.instance.currentHealth, 0, StatsManager.instance.maxHealth);
        healthslider.value = StatsManager.instance.currentHealth;
        Canvas.ForceUpdateCanvases();

        if (StatsManager.instance.currentHealth <= 0 && !isdead)
        {
            // gameObject.SetActive(false);
            Die();


    }

    void Die()
    {
        SceneManager.LoadScene("Gameoverscene");
    }
}
