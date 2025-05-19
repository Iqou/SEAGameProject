using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;
    public int quantity;

    private void OnValidate()
    {
        if (itemSO == null)
            return;

        sr.sprite = itemSO.icon;
        this.name = "Loot: " + itemSO.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("LootPickup");
            Destroy(gameObject, .5f); 
        }
    }
}