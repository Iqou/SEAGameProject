using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI; // Tambahkan ini

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;
    public StatsUI statsUI;
    public TMP_Text healthText;
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
        UpdateHealthText();
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

   
    private void UpdateHealthText()
    {

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
    }

}
