using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
public void ApplyItemEffects (ItemSO itemSO)
    {
        if (itemSO.currentHealth > 0)
            StatsManager.instance.UpdateHealth(itemSO.currentHealth);

        if (itemSO.maxHealth > 0)
            StatsManager.instance.UpdateMaxHealth(itemSO.maxHealth);

        if (itemSO.speed > 0)

            StatsManager.instance.UpdateSpeed(itemSO.speed);

         if (itemSO.damage > 0)

            StatsManager.instance.UpdateDamage(itemSO.damage);

        if (itemSO.duration > 0)
        
           StartCoroutine(EffectTimer(itemSO, itemSO.duration));
        
    }

    private IEnumerator EffectTimer(ItemSO itemSO, float duration)
    {
        yield return new WaitForSeconds(duration);

        if (itemSO.currentHealth > 0)
            StatsManager.instance.UpdateHealth(-itemSO.currentHealth);

        if (itemSO.maxHealth > 0)
            StatsManager.instance.UpdateMaxHealth(-itemSO.maxHealth);

        if (itemSO.speed > 0)

            StatsManager.instance.UpdateSpeed(-itemSO.speed);

        if (itemSO.damage > 0)

            StatsManager.instance.UpdateDamage(-itemSO.damage);
    }
}
