using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAltar : AreaEffect
{

    public override void AddEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Friendly"))
        {
            obj.AddComponent <HealEffect>();
        }
    }
    public override void RemoveEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Friendly"))
        {
            Destroy(obj.GetComponent<HealEffect>());
        }
    }
}
