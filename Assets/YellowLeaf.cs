using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YellowLeaf : Leaf
{
    public override void Interact(GameObject target)
    {
        target.AddComponent<Vulnerable>();
        Destroy(transform.gameObject);
    }
 
}
