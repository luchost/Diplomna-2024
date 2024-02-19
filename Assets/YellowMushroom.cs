using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMushroom : AIMovementController
{
    public float fireRate = 3.0f;
    public float nextFire = 0.0f;
    public float damage = 5;
    ParticleManager particleManager;
    public override void Start()
    {
        canMove = true;
        base.Start();
        particleManager = gameObject.AddComponent <ParticleManager>();
        particleManager.particleName = "Electric";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
        GetComponent<CharacterStats>().baseAttackDamage = damage;
    }
    public override bool IsValidTarget(GameObject target)
    {
        if (target.CompareTag("Enemy"))
            return true;

        return false;
    }
    public override float GetDesiredRange(GameObject target)
    {
        return 5f;
    }
    public override bool BetterTarget(GameObject currentTarget, GameObject potentialTarget)
    {
        if (Vector3.Distance(transform.position, currentTarget.transform.position) >= Vector3.Distance(transform.position, potentialTarget.transform.position))
            return true;

        return false;
    }
    public override void Interact(GameObject target)
    {
        if (Time.time >= nextFire)
        {
            particleManager.VFXStart();
            Collider[] enemies = Physics.OverlapSphere(transform.position, 5f, 1);
            foreach (var enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                    GetComponent<CharacterStats>().DealDamage(enemy.gameObject);
            }
            nextFire = Time.time + fireRate;
            particleManager.VFXStop();
        }
    }
}
