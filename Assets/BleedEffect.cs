using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedEffect : Effect
{
    int damage = 10;
    public override void Start()
    {
        transform.gameObject.GetComponent<EnemyMovementController>().agent.speed = transform.gameObject.GetComponent<EnemyMovementController>().agent.speed / 2;
        base.Start();
    }
    public override void GameUpdate()
    {
        transform.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
    }
    private void OnDestroy()
    {
        transform.gameObject.GetComponent<EnemyMovementController>().agent.speed = transform.gameObject.GetComponent<EnemyMovementController>().agent.speed * 2;
    }
}