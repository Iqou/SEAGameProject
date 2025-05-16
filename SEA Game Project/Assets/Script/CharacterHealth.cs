using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
