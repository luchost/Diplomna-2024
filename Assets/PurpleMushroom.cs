using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMushroom : AIMovementController
{
    public float fireRate = 3.0f;
    public float nextFire = 0.0f;
    public GameObject confuseBullet;
    public override void Start()
    {
        confuseBullet = Resources.Load("confuseBullet", typeof(GameObject)) as GameObject;
        canMove = false;
        base.Start();
    }
    public override float GetDesiredRange(GameObject target)
    {
        return 30f;
    }
    public override bool IsValidTarget(GameObject target)
    {
        if (target.CompareTag("Enemy"))
            return true;

        return false;
    }
    public override bool BetterTarget(GameObject currentTarget, GameObject potentialTarget)
    {
        if (Vector3.Distance(transform.position, currentTarget.transform.position) >= Vector3.Distance(transform.position, potentialTarget.transform.position))
            return false;

        return true;
    }
    public override void Interact(GameObject target)
    {
        if (Time.time > nextFire)
        {
            Vector3 distance = target.transform.position - transform.position;
            distance = Vector3.ClampMagnitude(distance, 2.2f);
            Vector3 Spawnpoint = transform.position + distance;
            Spawnpoint.y += 2f;
            GameObject BulletObj = Instantiate(confuseBullet, Spawnpoint, Quaternion.identity);

            BulletObj.GetComponent<Transform>().GetComponent<Confusebullet1>().direction = distance;
            nextFire = Time.time + fireRate;
        }
    }
}
