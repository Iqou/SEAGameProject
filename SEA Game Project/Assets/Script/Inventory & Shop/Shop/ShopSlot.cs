using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointEnterHandler
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    [SerializeField] private ShopManager shopManager;
    [SerializeField] private ShopInfo shopInfo;

    public int price;

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
        shopManager.TryBuyItem(itemSO, price);
    }
    public void OnPointEnter(PointerEventData eventData)
    {
        shopInfo.ShowItemInfo(itemSO);
    }

}
