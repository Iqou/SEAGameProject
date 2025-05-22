using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    
       [SerializeField] private ShopSlot[] shopSlots;

    [SerializeField] private InventoryManager inventoryManager;
    public void PopulateShopItems(List<ShopItems> shopItems)
    {
        for (int i = 0; i < shopItems.Count && i < shopSlots.Length; i++)
        {
            ShopItems shopItem = shopItems[i];
            shopSlots[i].Initialize(shopItem.itemSO, shopItem.price, this);

            shopSlots[i].gameObject.SetActive(true);
        }
        for (int i = shopItems.Count; i < shopSlots.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(false);
        }
    }
    public void TryBuyItem(ItemSO itemSO, int price)
    {
        if (itemSO != null && inventoryManager.gold >= price)
        {
            if (HasSpaceForItem(itemSO))
            {
                inventoryManager.gold -= price;
                inventoryManager.goldText.text = inventoryManager.gold.ToString();
                inventoryManager.AddItem(itemSO, 1);
            }
        }
    }
        private bool HasSpaceForItem(ItemSO itemSO)
    {
        foreach (var slot in inventoryManager.itemSlots)
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.maxQuantity)
                return true;
            else if (slot.itemSO == null)
                return true;
        }
        return false;
    }
    public bool SellItem(ItemSO itemSO)
    {
        if (itemSO == null)
            return false;

        int priceToSell = -1;

        // Cari item di slot toko
        foreach (var slot in shopSlots)
        {
            if (slot.itemSO == itemSO)
            {
                priceToSell = slot.price;
                break;
            }
        }

        // Jika item tidak ada di slot toko, pakai defaultPrice dari itemSO
        if (priceToSell == -1)
        {
            priceToSell = itemSO.defaultPrice > 0 ? itemSO.defaultPrice / 2 : 1;
        }

        inventoryManager.gold += priceToSell;
        inventoryManager.goldText.text = inventoryManager.gold.ToString();

        inventoryManager.RemoveItem(itemSO);
        return true;
    }


}

[System.Serializable]
public class ShopItems
{
    public ItemSO itemSO;
    public int price;
}