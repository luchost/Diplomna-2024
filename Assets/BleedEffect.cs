using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedEffect : Effect
{
    float damage = 1;
    ParticleManager particleManager;
    public override void Start()
    {
        transform.gameObject.GetComponent<EnemyMovementController>().agent.speed = transform.gameObject.GetComponent<EnemyMovementController>().agent.speed / 2;
        base.Start();
        particleManager = gameObject.AddComponent<ParticleManager>();
        particleManager.particleName = "Bleed";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
        particleManager.VFXStart();
    }
    public override void GameUpdate()
    {
        transform.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
    }
    private void OnDestroy()
    {
        transform.gameObject.GetComponent<EnemyMovementController>().agent.speed = transform.gameObject.GetComponent<EnemyMovementController>().agent.speed * 2;
    }
}