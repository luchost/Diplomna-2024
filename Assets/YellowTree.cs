using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTree : Effect
{
    public GameObject spawnble;
    private Vector3 minPosition;
    private Vector3 maxPosition;
    public override void GameUpdate()
    {
        minPosition.x = transform.position.x + 1;
        minPosition.y = transform.position.y;
        minPosition.z = transform.position.z + 1;
        maxPosition.x = transform.position.x + 10;
        maxPosition.y = transform.position.y;
        maxPosition.z = transform.position.z + 10;

        Vector3 Spawnponit = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        GameObject Leaf = Instantiate(spawnble, Spawnponit, Quaternion.identity);

    }
}
