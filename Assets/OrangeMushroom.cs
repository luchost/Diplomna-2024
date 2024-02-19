using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMushroom : AIMovementController
{
    public float fireRate = 3.0f;
    public float nextFire = 0.0f;
    public float damage = 5;
    public override void Start()
    {
        canMove = true;
        base.Start();
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
        return 10f;
    }
    public override bool BetterTarget(GameObject currentTarget, GameObject potentialTarget)
    {
        if (currentTarget.GetComponent<EnemyMovementController>().forcedTarget != null && potentialTarget.GetComponent<EnemyMovementController>().forcedTarget == null)
            return true;
        if (Vector3.Distance(transform.position, currentTarget.transform.position) >= Vector3.Distance(transform.position, potentialTarget.transform.position))
            return true;
        

        return false;
    }
    public override void Interact(GameObject target)
    {
        if (Time.time >= nextFire)
        {
            BurnEffect burn;
            if (!TryGetComponent(out burn))
            {
                target.AddComponent<BurnEffect>();
                target.GetComponent<EnemyMovementController>().forcedTarget = transform.gameObject;
            }            
            nextFire = Time.time + fireRate;
        }
    }

}
