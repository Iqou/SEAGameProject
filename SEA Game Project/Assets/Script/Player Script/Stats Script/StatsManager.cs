using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;
    public StatsUI statsUI;
    public TMP_Text healthText;

    [Header("Combat Stats")]
    public int damage;
    public float knockbackForce;
    public float weaponRange;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateHealthText(); // Pastikan teks diperbarui dari awal
    }


    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        UpdateHealthText();
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;

        // Batas atas dan bawah
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthText();
    }


    public void UpdateSpeed(int amount)
    {
        speed += amount;
        if (statsUI != null)
        {
            statsUI.UpdateAllStats();
        }
    }

    public void UpdateDamage(int amount)
    {
        damage += amount;
        if (statsUI != null)
        {
            statsUI.UpdateAllStats();
        }
    }

    private void UpdateHealthText()
    {
        Debug.Log($"[UI] UpdateHealthText called: {currentHealth}/{maxHealth}");

        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        }
        else
        {
            Debug.LogWarning("healthText is not assigned in StatsManager");
        }
    }

}