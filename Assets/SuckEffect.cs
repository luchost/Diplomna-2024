using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckEffect : Effect
{
    public float pushRate = 0.5f;
    public float nextPush = 0.0f;
    Collider[] affectedObjects;

    public override void GameUpdate()
    {
        if (Time.time > nextPush)
        {
            affectedObjects = Physics.OverlapSphere(transform.position, 10f);
            Debug.Log(affectedObjects.Length);
            foreach (var obj in affectedObjects)
            {
                if (obj.gameObject.TryGetComponent(out Rigidbody rigid))
                {
                    Vector3 direction = Vector3.Normalize(transform.position - obj.transform.position);
                    rigid.AddForce(direction * 10, ForceMode.VelocityChange);
                }
            }
            nextPush = Time.time + pushRate;
        }
    }
}
