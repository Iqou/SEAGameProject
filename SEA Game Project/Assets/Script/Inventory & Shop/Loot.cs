using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;
    public int quantity;

    public static event Action<ItemSO, int> OnItemLooted;

    private void OnValidate()
    {
        if (itemSO == null)
            return;

        sr.sprite = itemSO.icon;
        this.name = "Loot: " + itemSO.itemName;
    }

    private bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedUp) return;
        if (collision.CompareTag("Player"))
        {
            pickedUp = true;
            anim.Play("LootPickup");
            OnItemLooted.Invoke(itemSO, quantity);
            Destroy(gameObject, .5f);
        }
    }

}