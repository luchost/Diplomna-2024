using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : AIMovementController
{
    float timeAliveAfterCol = 1f;
    float aliveTime;
    public Vector3 direction;
    public override void Start()
    {
        base.Start();
        visionRange = 5f;
    }
    public override void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);
        base.FixedUpdate();
    }
    public override bool BetterTarget(GameObject currentTarget, GameObject potenialTarget)
    {
        return base.BetterTarget(currentTarget, potenialTarget);
    }

    public override float GetDesiredRange(GameObject target)
    {
        return 3f;
    }
    public override bool IsValidTarget(GameObject target)
    {
        if (target.CompareTag("Enemy"))
            return true;

        return false;
    }
    public override void ApproachPoint(Vector3 destination)
    {
        var vectorToTarget = (destination - transform.position);
        vectorToTarget.Normalize();
        GetComponent<Rigidbody>().AddForce(vectorToTarget * 0.1f, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        aliveTime = Time.time + timeAliveAfterCol;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Time.time > aliveTime)
            Destroy(transform.gameObject);
    }
}
