using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;
    public int health = 200;
    public float attackRange = 20f;
    public float fireRate = 3.0f;
    public float nextFire = 0.0f;
    public float consumeTime = 0.0f;
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
    
    }
   
    public void Attack(GameObject target) 
    {

        if (Time.time > nextFire)
        {
            Vector3 distance = target.transform.position - transform.position;
            distance = Vector3.ClampMagnitude(distance, 2.2f);
            Vector3 Spawnpoint = transform.position + distance;
            Spawnpoint.y += 2f;
            GameObject BulletObj = Instantiate(Bullet, Spawnpoint, Quaternion.identity);

            BulletObj.GetComponent<Transform>().GetComponent<Bullet>().direction = distance;
            nextFire = Time.time + fireRate;
        }
    }
    public void Eat(GameObject target) 
    {
        if (consumeTime == 0.0f)
            consumeTime = Time.time + 3.0f;
        else if (Time.time >= consumeTime)
        {
            consumeTime = 0.0f;
            Destroy(target);
        }
    }
}
