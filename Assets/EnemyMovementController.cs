using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : AIMovementController
{
    public override void Start()
    {
        canMove = true;
        base.Start();
    }
    public override bool IsValidTarget(GameObject target)
    {
        if (pickFriendly && target.CompareTag("Enemy"))
        {
            return true;
        }
        if (target.CompareTag("Friendly") || target.CompareTag("Food"))
            return true;

        return false;
    }


    public override float GetDesiredRange(GameObject target)
    {
        if(target.CompareTag("Friendly"))
            return 20f;
        if (pickFriendly && target.CompareTag("Enemy"))
            return 20f;
        return 2f;
    }

    public override void Interact(GameObject target)
    {
        if (target.CompareTag("Enemy") && pickFriendly)
        {
            gameObject.GetComponent<EnemyController>().Attack(target);
        }
        if (target.CompareTag("Friendly"))
            gameObject.GetComponent<EnemyController>().Attack(target);
        else
            gameObject.GetComponent<EnemyController>().Eat(target);
    }

    public override bool BetterTarget(GameObject currentTarget, GameObject potentialTarget)
    {
        if (currentTarget.CompareTag("Friendly") && potentialTarget.CompareTag("Food"))
            return true;
        if (currentTarget.CompareTag("Friendly") && potentialTarget.CompareTag("Enemy") && pickFriendly)
            return true;
        if (currentTarget.CompareTag("Food") && potentialTarget.CompareTag("Enemy") && pickFriendly)
            return true;

        return false;
    }
}
