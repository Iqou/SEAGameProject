using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    public static event Action<ShopManager, bool> OnShopStateChanged;
    [SerializeField] private List<ShopItems> shopItems;

    [SerializeField] private ShopSlot[] shopSlots;

    [SerializeField] private InventoryManager inventoryManager;
    private void Start()
    {
        PopulateShopItems();
        OnShopStateChanged?.Invoke(this, true);
    }
    public void PopulateShopItems()
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
    public void SellItem(ItemSO itemSO)
    {
        if(itemSO == null)
            return;

        foreach (var slot in shopSlots)
        {
            if(slot.itemSO == itemSO)
            {
                inventoryManager.gold += slot.price;
                inventoryManager.goldText.text = inventoryManager.gold.ToString() ;
                return;
            }
        }
    }
}

[System.Serializable]
public class ShopItems
{
    public ItemSO itemSO;
    public int price;
}