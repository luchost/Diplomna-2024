using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAnimations : MonoBehaviour
{
    public GameObject particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        particleSystem.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        particleSystem.SetActive(false);
    }
}
