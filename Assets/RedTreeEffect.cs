using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTreeEffect : Effect
{
    public GameObject spawnble;
    private Vector3 minPosition ;
    private Vector3 maxPosition ;
    public float spawnRate = 10.0f;
    public float nextSpawn = 0.0f;
    public override void Start()
    {
        spawnble = Resources.Load("Apple", typeof(GameObject)) as GameObject;
        minPosition.x = transform.position.x - 5;
        minPosition.y = transform.position.y;
        minPosition.z = transform.position.z - 5;
        maxPosition.x = transform.position.x + 5;
        maxPosition.y = transform.position.y;
        maxPosition.z = transform.position.z + 5;

        base.Start();
    }
    public  override void GameUpdate()
    {
        if (Time.time > nextSpawn)
        {
            Vector3 Spawnponit = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
            Instantiate(spawnble, Spawnponit, Quaternion.identity);
            nextSpawn += spawnRate;
        }  
    }

}
