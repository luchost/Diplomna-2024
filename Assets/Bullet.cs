using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 20f;
    public float damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = direction.normalized * speed;
        StartCoroutine( DestroyAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator DestroyAfterTime()
    {        
        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CharacterStats stats;
        if (collision.gameObject.TryGetComponent(out stats))
        {
            stats.TakeDamage(damage);
        }
        Destroy(transform.gameObject);
    }
}
