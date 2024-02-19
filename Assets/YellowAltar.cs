using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAltar : AreaEffect
{
    ParticleManager particleManager;
    private void Start()
    {
        particleManager = gameObject.AddComponent<ParticleManager>();
        particleManager.particleName = "Stun";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
        particleManager.VFXStart();
        particleManager.VFXStop();
    }
    public override void AddEffectsForObject(GameObject obj)
    {
        if (obj.TryGetComponent<EnemyMovementController>(out EnemyMovementController enemyMovementController))
        {
            enemyMovementController.enabled = !enemyMovementController.enabled;
            StartCoroutine(WaitForStatusEnd(obj));
        }
    }
   
    
    IEnumerator WaitForStatusEnd(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.GetComponent<EnemyMovementController>().enabled = !obj.GetComponent<EnemyMovementController>().enabled;

    }
}
