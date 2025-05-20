using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public int gold;
    public TMP_Text goldText;

    private void Start()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable: Mendaftarkan AddItem");
        Loot.OnItemLooted += AddItem;
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable: Melepas AddItem");
        Loot.OnItemLooted -= AddItem;
    }


    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }

        // Cek apakah item sudah ada di slot
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == itemSO)
            {
                slot.quantity += quantity;
                slot.UpdateUI();
                return;
            }
        }

        // Kalau belum ada, cari slot kosong
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == null)
            {
                slot.itemSO = itemSO;
                slot.quantity = quantity;
                slot.UpdateUI();
                return;
            }
        }
    }

}
