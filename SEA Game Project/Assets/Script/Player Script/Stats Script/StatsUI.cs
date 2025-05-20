using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;

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
                statsOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                UpdateAllStats();
                statsCanvas.alpha = 1;
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
    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }
}
