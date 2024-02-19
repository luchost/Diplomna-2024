using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : Effect
{
    public override float OnBeforeTakeDamage(float damage)
    {
        return damage+5;
    }
}
