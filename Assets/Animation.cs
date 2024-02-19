using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public GameObject Rock;
    public GameObject Tree;
    public GameObject Mushroom;

    float nextthing;
    int ToDo = 0;
    private void Start()
    {
        nextthing = Time.time + 2f;
    }
    private void Update()
    {
        if (Time.time > nextthing)
        {
            if (ToDo == 0)
            {
                effect1.SetActive(true);
                Rock.GetComponent<MeshRenderer>().material.color = Color.blue;
                nextthing = Time.time + 3f;
            }
            if (ToDo == 1)
            {
                effect2.SetActive(true);
                Tree.GetComponent<MeshRenderer>().material.color = Color.green;
                nextthing = Time.time + 3f;
            }
            if (ToDo == 2)
            {
                effect3.SetActive(true);
                Mushroom.GetComponent<MeshRenderer>().material.color = Color.magenta;
                nextthing = Time.time + 3f;
            }
            ToDo++;
        }
    }

}
