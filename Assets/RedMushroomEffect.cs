using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroomEffect : Effect
{
    public GameObject mushroom;

    public override float OnBeforeTakeDamage(float damage)
    {
        mushroom.GetComponent<CharacterStats>().TakeDamage(damage);
        return 0; // the mushroom absorbs the damage
    }
}
