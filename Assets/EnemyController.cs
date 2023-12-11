using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;
    public int health = 200;
    public float attackRange = 20f;
    public GameObject target;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange )
        {
            Vector3 Spawnpoint = transform.position + target.transform.position / 2 ;
            Spawnpoint.y = transform.position.y+2;
            GameObject BulletObj = Instantiate(Bullet, Spawnpoint, Quaternion.identity);
            BulletObj.GetComponent<Transform>().GetComponent<Bullet>().orientaion = target.transform;


        }
    }
    public void TakeDamage(int damage) 
    {
       Effect[] effects = gameObject.GetComponents<Effect>();
        foreach (var effect in effects)
        {
            damage = effect.OnBeforeTakeDamage(damage);
        }
        health -= damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Attack"))
        {
            TakeDamage(collision.transform.gameObject.GetComponent<Bullet>().damage);
        }
    }
}
