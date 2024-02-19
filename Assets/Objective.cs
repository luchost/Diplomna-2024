using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    GameObject[] allEnemies;
    public GameObject winText;
    public GameObject nextLevel;
    public NextButton next;

    private void Awake()
    {
        winText.SetActive(false);
        nextLevel.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex != 6)
        {
            next.id = SceneManager.GetActiveScene().buildIndex + 1;
        }else{
            next.id = 4;
        }
    }
    private void FixedUpdate()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");  //returns GameObject[]
        if (allEnemies.Length == 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            winText.SetActive(true);
            nextLevel.SetActive(true);
        }
    }
}
