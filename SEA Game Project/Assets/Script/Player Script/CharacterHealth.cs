using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthslider;

    void Start()
    {
        StatsManager.instance.currentHealth = StatsManager.instance.maxHealth;
        healthslider.maxValue = StatsManager.instance.maxHealth;
        healthslider.value = StatsManager.instance.currentHealth;
    }
    public void ChangeHealth(int amount)
    {
        StatsManager.instance.currentHealth += amount;
        StatsManager.instance.currentHealth = Mathf.Clamp(StatsManager.instance.currentHealth, 0, StatsManager.instance.maxHealth);
        healthslider.value = StatsManager.instance.currentHealth;
        Canvas.ForceUpdateCanvases();

        if (StatsManager.instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
