using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 200;
    public float health = 200;
    public float baseAttackDamage;
    public Slider healthBar;

    private void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (gameObject.name == "Player")
            {
                SceneManager.LoadScene("RestartLevelOrQuit");
                Cursor.lockState = CursorLockMode.None;
                HelpPopUps.Instance.TutorialSetText(0, "");
            }
            else
                Destroy(transform.gameObject);
        }
    }

    public void DealDamage(GameObject target)
    {
        float damage = baseAttackDamage;
        Effect[] effects = gameObject.GetComponents<Effect>();
        foreach (var effect in effects)
        {
            damage = effect.OnBeforeDealDamage(damage);
        }
        target.GetComponent<CharacterStats>().TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        Effect[] effects = gameObject.GetComponents<Effect>();
        foreach (var effect in effects)
        {
            damage = effect.OnBeforeTakeDamage(damage);
        }
        health -= damage;
        healthBar.value = health / maxHealth;
    }
}
