using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLeaf : Leaf
{
    public override void Interact(GameObject target)
    {
        target.AddComponent<Suffocate>();
        Destroy(transform.gameObject);
    }
}
