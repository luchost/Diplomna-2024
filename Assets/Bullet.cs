using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody rigidbody;
    public Transform orientaion;
    public GameObject me;
    private float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = orientaion.forward* speed;
       StartCoroutine( DestroyAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator  DestroyAfterTime()
    {
        
        yield return new WaitForSeconds(2f);
        Destroy(me);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(me);
    }
}
