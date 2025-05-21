using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public UseItem useItem;
    public int gold;
    public TMP_Text goldText;
    public GameObject lootPrefab;
    public Transform player;

    private void Start()
    {
        goldText.text = gold.ToString();
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

        int remaining = quantity;

        // 1. Tambahkan ke slot yang sudah berisi itemSO yang sama
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.maxQuantity)
            {
                int space = itemSO.maxQuantity - slot.quantity;
                int addAmount = Mathf.Min(remaining, space);

                slot.quantity += addAmount;
                slot.UpdateUI();

                remaining -= addAmount;
                if (remaining <= 0) return;
            }
        }

        // 2. Tambahkan ke slot kosong
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == null)
            {
                int addAmount = Mathf.Min(remaining, itemSO.maxQuantity);

                slot.itemSO = itemSO;
                slot.quantity = addAmount;
                slot.UpdateUI();

                remaining -= addAmount;
                if (remaining <= 0) return;
            }
        }

        // 3. Jika masih ada sisa, jatuhkan ke dunia
        if (remaining > 0)
        {
            Debug.Log($"Inventory penuh untuk {itemSO.name}, menjatuhkan sisa: {remaining}");
            DropLoot(itemSO, remaining);
        }
    }

    public void DropItem(InventorySlot slot)
    {
        if (slot.itemSO != null && slot.quantity > 0)
        {
            DropLoot(slot.itemSO, 1);  // drop 1 item saja per klik kanan
            slot.quantity--;

            if (slot.quantity <= 0)
            {
                slot.itemSO = null;
            }

            slot.UpdateUI();
        }
    }





    private void DropLoot(ItemSO itemSO, int quantity)
    {
        Vector3 dropOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        GameObject dropped = Instantiate(lootPrefab, player.position + dropOffset, Quaternion.identity);
        Loot loot = dropped.GetComponent<Loot>();
        loot.Initialized(itemSO, quantity);
    }




    public void UseItem(InventorySlot slot)
    {
        if(slot.itemSO != null && slot.quantity >= 0)
        {
            useItem.ApplyItemEffects(slot.itemSO);

            slot.quantity--;
            if(slot.quantity <= 0)
            {
                slot.itemSO = null;
            }
            slot.UpdateUI();
        }
    }
}