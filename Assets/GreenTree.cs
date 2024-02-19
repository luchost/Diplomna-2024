using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTree : Effect
{
    public GameObject spawnable;
    private Vector3 minPosition;
    private Vector3 maxPosition;
    float minVelocity = 0.1f;
    float maxVelocity = 0.2f;

    public override void Start()
    {
        base.Start();
        minPosition.x = transform.position.x - 2;
        minPosition.y = transform.position.y + 4;
        minPosition.z = transform.position.z - 2;
        maxPosition.x = transform.position.x + 2;
        maxPosition.y = transform.position.y + 4;
        maxPosition.z = transform.position.z + 2;

        spawnable = Resources.Load("Leaf", typeof(GameObject)) as GameObject;
    }
    public override void GameUpdate()
    {
        Vector3 Spawnpoint = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        GameObject Leaf = Instantiate(spawnable, Spawnpoint, Quaternion.identity);
        Leaf.AddComponent<GreenLeaf>();
        var randomDir = Random.insideUnitCircle.normalized * Random.Range(minVelocity, maxVelocity);
        var vector = new Vector3(randomDir.x, 0, randomDir.y);
        Leaf.GetComponent<GreenLeaf>().direction = vector;
    }
}
