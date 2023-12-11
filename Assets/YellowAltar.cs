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
   
        // Start is called before the first frame update
        void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitForStatusEnd(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.GetComponent<EnemyMovementController>().enabled = !obj.GetComponent<EnemyMovementController>().enabled;

    }
}
