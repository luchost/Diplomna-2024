using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShooting : MonoBehaviour
{
    public GameObject Bullet;
    Vector3 bulletOffset = new Vector3(-1f, 2f, 1f);
    float nextShot;
    void Update()
    {
        Vector3 Spawnpoint = transform.position + transform.TransformDirection(bulletOffset);
        if (Time.time > nextShot)
        {
            GameObject BulletObj = Instantiate(Bullet, Spawnpoint, Quaternion.identity);
            BulletObj.GetComponent<Transform>().GetComponent<Bullet>().direction = transform.forward;
            nextShot = Time.time + 2f;
        }
    }
}
