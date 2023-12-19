using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : Effect
{
    int damage = 20;
    public override void GameUpdate()
    {
        transform.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
    }
    public override int OnBeforeTakeDamage(int damage)
    {
        return base.OnBeforeTakeDamage(damage);
    }
}
