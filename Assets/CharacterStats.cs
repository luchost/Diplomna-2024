using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 200;
    public int health = 100;
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
