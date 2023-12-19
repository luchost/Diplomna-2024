using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAltar : AreaEffect
{
    public override void AddEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            obj.AddComponent<BleedEffect>();
        }
    }
    public override void RemoveEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            Destroy(obj.GetComponent<BleedEffect>());
        }
    }
}
