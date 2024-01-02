using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAltar : AreaEffect
{
    public override void AddEffectsForObject(GameObject obj)
    {
        obj.GetComponent<EnemyMovementController>().enabled = !obj.GetComponent<EnemyMovementController>().enabled;
        StartCoroutine(WaitForStatusEnd(obj));

    }
   
    
    IEnumerator WaitForStatusEnd(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.GetComponent<EnemyMovementController>().enabled = !obj.GetComponent<EnemyMovementController>().enabled;

    }
}
