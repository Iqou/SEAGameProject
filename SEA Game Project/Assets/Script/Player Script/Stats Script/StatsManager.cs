using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsManager :MonoBehaviour
{
    public static StatsManager instance;
    [Header("Combat Stats")]
    public int damage;
    public float knockbackForce;
    public float weaponRange;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
