using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(UpdateCall());
    }
    IEnumerator UpdateCall()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GameUpdate();
        }
    }

    public virtual void GameUpdate() {}
    public virtual float OnBeforeTakeDamage(float damage) { return damage; }
}

public class TestEffect : Effect
{
    public override void GameUpdate()
    {
        Debug.Log("We are updating!");
    }
}