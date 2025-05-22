using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;
    public TMP_Text levelPointsText;

    private bool statsOpen = false;
    private void Start()
    {
        UpdateAllStats();
    }
    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
            if (statsOpen)
            {
                Time.timeScale = 1;
                UpdateAllStats();
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                statsOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                UpdateAllStats();
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                statsOpen = true;
            }
      

    }
    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.instance.damage;

    }
    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.instance.speed;

    }

    public void UpdateHealth()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "Health: " + StatsManager.instance.maxHealth;
    }
    public void OnUpgradeHealthClicked()
    {
        StatsManager.instance.UpgradeStat("health");
    }

    public void OnUpgradeDamageClicked()
    {
        StatsManager.instance.UpgradeStat("damage");
    }

    public void OnUpgradeSpeedClicked()
    {
        StatsManager.instance.UpgradeStat("speed");
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateHealth();
        if (levelPointsText != null)
            levelPointsText.text = "Points: " + StatsManager.instance.levelPoints;
    }
}
