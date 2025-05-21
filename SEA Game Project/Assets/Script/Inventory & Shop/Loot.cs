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

    public bool canBePickedUp = true;

    public static event Action<ItemSO, int> OnItemLooted;
    Audiomanager Audiomanager;

  private void Awake()
  {
	Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
  }
    private void OnValidate()
    {
        if (itemSO == null)
            return;

    UpdateAppearance();
    }

    public void Initialized(ItemSO itemSO, int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
        canBePickedUp = false;
        UpdateAppearance();

    }

    private void UpdateAppearance()
    {
        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;
    }

    private bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedUp) return;
        if (collision.CompareTag("Player") && canBePickedUp == true)
        {
            pickupitem();
            pickedUp = true;
            anim.Play("LootPickup");
            OnItemLooted.Invoke(itemSO, quantity);
            Destroy(gameObject, .5f);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBePickedUp = true;
        }
    }
    void pickupitem(){
        Audiomanager.PlaySFX(Audiomanager.pickitem);
    }
}