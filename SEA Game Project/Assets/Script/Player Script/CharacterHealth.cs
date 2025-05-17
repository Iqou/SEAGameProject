using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 10;
    public Slider healthslider;

    void Start()
    {
        currentHealth = maxHealth;
        healthslider.maxValue = maxHealth;
        healthslider.value = currentHealth;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        healthslider.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
