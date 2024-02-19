using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confusebullet1 : MonoBehaviour
{

    public Vector3 direction;
    private float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = direction.normalized * speed;
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }
    IEnumerator UnConfuse(GameObject target)
    {
        yield return new WaitForSeconds(3f);
       target.GetComponent<EnemyMovementController>().pickFriendly = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMovementController>().pickFriendly = true;
            StartCoroutine(UnConfuse(collision.gameObject));
        }
            Destroy(transform.gameObject);
    }
}
