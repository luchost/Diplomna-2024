using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeBullet : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 20f;
    public float damage = 20;
    ParticleManager particleManager;
    // Start is called before the first frame update
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = direction.normalized * speed;
        StartCoroutine(DestroyAfterTime());
        particleManager = gameObject.AddComponent<ParticleManager>();
        particleManager.particleName = "Wind";
        particleManager.InstaniateVFX();
        particleManager.particle = GetComponentInChildren<ParticleSystem>();
        particleManager.VFXStop();
    }

    private void DealDamage()
    {
        particleManager.VFXStart();
        Collider[] enemies = Physics.OverlapSphere(transform.position, 10f, 1);
        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
                enemy.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
        }
        particleManager.VFXStop();
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        DealDamage();
        Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        DealDamage();
        Destroy(transform.gameObject);
        
    }
}
