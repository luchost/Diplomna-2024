using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleAltar : AreaEffect
{
    public override void AddEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Friendly"))
        {
            obj.AddComponent<MushroomBoost>();
        }
    }
    public override void RemoveEffectsForObject(GameObject obj)
    {
        if (obj.CompareTag("Friendly"))
        {
            Destroy(obj.GetComponent<MushroomBoost>());
        }
    }
}
