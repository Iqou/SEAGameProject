using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public int quantity;

    public Image itemImage;
    public TMP_Text quantityText;

    private InventoryManager inventoryManager;
    private static ShopManager activeShop;


    private void Start()
    {
        inventoryManager = GetComponentInParent<InventoryManager>();
    }


    private void OnEnable()
    {
        ShopManager.OnShopStateChanged += HandleShopStateChanged;
    }
    private void OnDisable()
    {
        ShopManager.OnShopStateChanged -= HandleShopStateChanged;
    }

    private void HandleShopStateChanged(ShopManager shopManager, bool isOpen)
    {
        activeShop = isOpen ? shopManager : null;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (quantity > 0)
        {

            if (eventData.button == PointerEventData.InputButton.Left)
            {

                if (activeShop != null)
                {
                    activeShop.SellItem(itemSO);
                    quantity--;
                    UpdateUI();
                }
                else
                {



                    if (itemSO.currentHealth > 0 && StatsManager.instance.currentHealth >= StatsManager.instance.maxHealth)
                        return;

                    inventoryManager.UseItem(this);
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                inventoryManager.DropItem(this);
            }

        }
    }

    public void UpdateUI()
    {
        if (quantity <= 0)
            itemSO = null;


        if (itemSO != null)
        {
            itemImage.sprite = itemSO.icon;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }

    }