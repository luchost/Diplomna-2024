using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect :Effect
{
    public override void GameUpdate()
    {
        int currentHealth = this.GetComponentInParent<CharacterStats>().health;
        int maxHealth = this.GetComponentInParent<CharacterStats>().maxHealth;
        currentHealth += 5;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
