using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAltar : AreaEffect
{
    public override void AddEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            obj.AddComponent<SuckEffect>();
        }
    }
    public override void RemoveEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            Destroy(obj.GetComponent<SuckEffect>());
        }
    }
}
