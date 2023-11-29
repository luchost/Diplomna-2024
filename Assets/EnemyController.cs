using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage) 
    {
       Effect[] effects = gameObject.GetComponents<Effect>();
        foreach (var effect in effects)
        {
            damage = effect.OnBeforeTakeDamage(damage);
        }
        health -= damage;
    }
}
