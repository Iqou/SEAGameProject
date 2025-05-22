 using UnityEngine;
 using TMPro;
using NUnit.Framework;
using System.Globalization;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Collections;


public class ShopInfo : MonoBehaviour
{
    public CanvasGroup infoPanel;

    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    [Header ("Stat Fields")]
    public TMP_Text[] statTexts;

    private RectTransform infoPanelRect;

    private void Awake()
    {
        infoPanelRect = GetComponent<RectTransform>();
    }

    public void ShowItemInfo (ItemSO itemSO)
    {
        infoPanel.alpha = 1;

        itemNameText.text = itemSO.itemName;
        itemDescriptionText.text = itemSO.itemDescription;

        List<string> stats = new List<string>();
        if (itemSO.currentHealth > 0) stats.Add("Health: " + itemSO.currentHealth.ToString());
        if (itemSO.damage > 0) stats.Add("Damage: " + itemSO.damage.ToString());
        if (itemSO.speed > 0) stats.Add("Speed: " + itemSO.speed.ToString());
        if (itemSO.duration > 0) stats.Add("Duration: " + itemSO.duration.ToString());

        if (stats.Count <= 0)
            return;

        for (int i = 0; i<statTexts.Length; i++)
        {
            if(i < stats.Count)
            {
                statTexts[i].text = stats[i];
                statTexts[i].gameObject.SetActive(true);
            }
            else
            {
                statTexts[i].gameObject.SetActive(false);
            }
        }
    }

    public void HideItemInfo()
    {
        infoPanel.alpha = 0;

        itemNameText.text = "";
        itemDescriptionText.text = "";
    }

    public void FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 offset = new Vector3(10, -10, 0);

        infoPanelRect.position = mousePosition + offset;
    }
} 
