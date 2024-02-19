using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suffocate : MonoBehaviour
{
    public float suffocateTime = 5f;
    public float suffocate;
    // Start is called before the first frame update
    void Start()
    {
        suffocate = Time.time + suffocateTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > suffocate)
            Destroy(transform.gameObject);
    }
}
