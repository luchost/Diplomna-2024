using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBoost : Effect
{
    public override float OnBeforeDealDamage(float damage)
    {
        return damage + 5;
    }
}
