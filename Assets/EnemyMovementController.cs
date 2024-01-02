using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : AIMovementController
{
    public override bool IsValidTarget(GameObject target)
    {
        if (target.CompareTag("Friendly") || target.CompareTag("Food"))
            return true;

        return false;
    }


    public override float GetDesiredRange(GameObject target)
    {
        if(target.CompareTag("Friendly"))
            return 20f;

        return 2f;
    }

    public override void Interact(GameObject target)
    {
        if(target.CompareTag("Friendly"))
            gameObject.GetComponent<EnemyController>().Attack(target);
        else
            gameObject.GetComponent<EnemyController>().Eat(target);
    }

    public override bool BetterTarget(GameObject currentTarget, GameObject potenialTarget)
    {
        if (currentTarget.CompareTag("Friendly") && potenialTarget.CompareTag("Food"))
            return true;

        return false;
    }
}
