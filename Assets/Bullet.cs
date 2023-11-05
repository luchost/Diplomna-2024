using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody rigidbody;
    public Transform orientaion;
    private float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = orientaion.forward* speed;
        DestroyAfterTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator  DestroyAfterTime()
    {
       yield return new WaitForSeconds(2f);
        Destroy(this);
    }
}
