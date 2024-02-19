using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTree : Effect
{
    public float pushRate = 0.5f;
    public float nextPush = 0.0f;
    ParticleManager particleManager;
    Collider[] affectedObjects;
    public override void Start()
    {
        base.Start();
        particleManager = gameObject.AddComponent<ParticleManager>();
        particleManager.particleName = "Wind";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
        
        
    }
    public override void GameUpdate()
    {
        if (Time.time > nextPush)
        {
            particleManager.VFXStart();
            affectedObjects = Physics.OverlapSphere(transform.position, 10f);
            Debug.Log(affectedObjects.Length);
            foreach (var obj in affectedObjects)
            {
                if (obj.gameObject.TryGetComponent(out Rigidbody rigid))
                {
                    Vector3 direction = Vector3.Normalize(obj.transform.position - transform.position);
                    rigid.AddForce(direction * 10, ForceMode.VelocityChange);
                }
            }
            nextPush = Time.time + pushRate;
            particleManager.VFXStop();
        }
    }

    private void FixedUpdate()
    {
        
    }
}
