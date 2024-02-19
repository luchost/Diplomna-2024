using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : AreaEffect
{
    public override void AddEffectsForObject(GameObject obj)
    {
        if (obj.GetComponent<MovementController>() != null)
        {
            obj.AddComponent<RedMushroomEffect>().mushroom = transform.gameObject;
        }
    }
    public override void RemoveEffectsForObject(GameObject obj)
    {
        Destroy(obj.GetComponent<RedMushroomEffect>());
    }
}
