﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect :Effect
{
    public override void GameUpdate()
    {
        int currentHealth = transform.gameObject.GetComponent<CharacterStats>().health;
        int maxHealth = transform.gameObject.GetComponent<CharacterStats>().maxHealth;
        transform.gameObject.GetComponent<CharacterStats>().health += 5;
        if (currentHealth > maxHealth)
        {
            transform.gameObject.GetComponent<CharacterStats>().health = maxHealth;
        }
    }
}
