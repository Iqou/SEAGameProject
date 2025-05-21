using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    [SerializeField] private ShopManager shopManager;

    private int price;

    public void Initialize(ItemSO newItemSO, int price, ShopManager shopManager)
    {
        this.shopManager = shopManager; // tambahkan ini!
        itemSO = newItemSO;
        itemImage.sprite = itemSO.icon;
        itemNameText.text = itemSO.itemName;
        this.price = price;
        priceText.text = price.ToString();
    }


    public void OnBuyButtonClicked()
    {
        Debug.Log($"[ShopSlot] Buy button clicked for: {itemSO.itemName}, Price: {price}");
        if (shopManager == null)
        {
            Debug.LogError("ShopManager is NULL in ShopSlot!");
            return;
        }

        shopManager.TryBuyItem(itemSO, price);
    }

}
