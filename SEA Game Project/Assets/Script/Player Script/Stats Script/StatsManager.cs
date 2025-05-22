using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI; // Tambahkan ini

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;
    public StatsUI statsUI;
    public TMP_Text healthSliderText;
    public Slider healthSlider; // Tambahkan ini

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

    [Header("Points")]
    public int levelPoints;

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

    private void Update()
    {
        UpdateHealthSlider();
    }

    private void Start()
    {
        UpdateHealthSlider();
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        UpdateHealthSlider();
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;

        // Clamp
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthSlider();

        // Update slider juga
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
            Canvas.ForceUpdateCanvases();
        }
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




    private void UpdateHealthSlider()
    {
        Debug.Log($"[UI] UpdateHealthSlider called: {currentHealth}/{maxHealth}");

        
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.LogWarning("healthSlider is not assigned in StatsManager");
        }

        
        if (healthSliderText != null)
        {
            healthSliderText.text = $"{currentHealth} / {maxHealth}";
        }
        else
        {
            Debug.LogWarning("healthSliderText is not assigned in StatsManager");
        }
    }
    public void UpgradeStat(string statName)
    {
        if (levelPoints <= 0)
        {
            Debug.Log("Tidak ada levelPoints tersisa.");
            return;
        }

        switch (statName.ToLower())
        {
            case "health":
                UpdateMaxHealth(10);
                UpdateHealth(10); // ikut menambah currentHealth
                break;
            case "damage":
                UpdateDamage(1);
                break;
            case "speed":
                UpdateSpeed(1);
                break;
            default:
                Debug.LogWarning("Stat tidak dikenal: " + statName);
                return;
        }

        levelPoints--;

        if (statsUI != null)
        {
            statsUI.UpdateAllStats();
        }

        Debug.Log($"Stat '{statName}' berhasil di-upgrade. Sisa poin: {levelPoints}");
    }


}
