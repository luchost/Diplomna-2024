using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : Effect
{
    float damage = 2;
    float duration = 20f;
    float endTime;
    ParticleManager particleManager;
    public override void Start()
    {    
        base.Start();
        endTime = duration + Time.time;
        particleManager = gameObject.AddComponent<ParticleManager>();
        particleManager.particleName = "Fire";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
        particleManager.VFXStart();
    }
    public override void GameUpdate()
    {

        if (Time.time > endTime)
        {
            Destroy(this);
        }else{ 
            transform.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
        }
    }
    public override float OnBeforeTakeDamage(float damage)
    {
        return base.OnBeforeTakeDamage(damage);
    }
}
