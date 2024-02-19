using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMushroom : AIMovementController
{
    public float damage = 50;
    ParticleManager particleManager;
    public override void Start()
    {
        canMove = true;
        base.Start();
        GetComponent<CharacterStats>().baseAttackDamage = damage;
        particleManager = gameObject.AddComponent<ParticleManager>();
        particleManager.particleName = "Boom";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
    }
    public override bool IsValidTarget(GameObject target)
    {
        if (target.CompareTag("Enemy"))
            return true;

        return false;
    }
    public override float GetDesiredRange(GameObject target)
    {
        return 3f;
    }
    public override bool BetterTarget(GameObject currentTarget, GameObject potentialTarget)
    {
        if (Vector3.Distance(transform.position, currentTarget.transform.position) >= Vector3.Distance(transform.position, potentialTarget.transform.position))
            return true;

        return false;
    }
    public override void Interact(GameObject target)
    {
            particleManager.VFXStart();
            Collider[] enemies = Physics.OverlapSphere(transform.position, 10f, 1);
            foreach (var enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                    GetComponent<CharacterStats>().DealDamage(enemy.gameObject);
            }
        particleManager.VFXStop();
        Destroy(transform.gameObject);
    }
}
