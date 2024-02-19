using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementController : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public float visionRange = 30.0f;
    private float nextFind = 0.0f;
    private float timeToNextFind = 5.0f;
    public bool canMove = true;
    public bool pickFriendly =  false;
    public GameObject forcedTarget;
    // Start is called before the first frame update
    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public virtual void FixedUpdate()
    {
        // Find or improve the target
        // (this will also handle the case if the current target is invalid)
        if (forcedTarget != null)
        {
            target = forcedTarget;
        }
        else
        {
            if (target == null)
            {
                target = FindBestTarget();
                nextFind = Time.time + timeToNextFind;
            }
            if (Time.time > nextFind)
            {
                nextFind += timeToNextFind;
                target = FindBestTarget();
            }
        }
        if (target == null)
            return;

        float range = GetDesiredRange(target);
        Effect[] effects = gameObject.GetComponents<Effect>();
        foreach (var effect in effects)
        {
            range = effect.ModifyRange(range);
        }
        if (Vector3.Distance(transform.position, target.transform.position) <= range )
        {
            ApproachPoint(transform.position);
            Interact(target);
        } else if (IsValidTarget(target) && canMove)
        {
            ApproachPoint(target.transform.position);
        } else
        {
            target = null; // invalid target
        }
    }

    // Finds the best target in range, for which IsValidTarget is 'true'
    GameObject FindBestTarget() {
        var bestTarget = target;
        var objects = Physics.OverlapSphere(transform.position, visionRange);
        foreach (var obj in objects)
            if (CompareTarget(bestTarget, obj.gameObject))
                bestTarget = obj.gameObject;
        return bestTarget;
    }
    bool CompareTarget(GameObject currentTarget, GameObject potentialTarget) {
        if (!IsValidTarget(potentialTarget))
            return false;
        if (currentTarget == null)
            return true;
        return BetterTarget(currentTarget, potentialTarget);
    }
    public virtual void ApproachPoint(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
    public virtual bool BetterTarget(GameObject currentTarget, GameObject potentialTarget) {
        return true;
    }
    public virtual bool IsValidTarget(GameObject target) {
        return false;
    }
    public virtual float GetDesiredRange(GameObject target) {
        return 0;
    }
    public virtual void Interact(GameObject target) {
    }
}
