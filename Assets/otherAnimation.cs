using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherAnimation : MonoBehaviour
{
    public GameObject particle;
    private void Awake()
    {
        particle.SetActive(true);
    }
    
}
