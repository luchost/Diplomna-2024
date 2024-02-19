using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeLeaf : Leaf
{
    public override void Interact(GameObject target)
    {
        target.AddComponent<BurnEffect>();
        Destroy(transform.gameObject);
    }
}
