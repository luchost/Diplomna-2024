using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public int id;

    public void LoadNext()
    {
        SceneManager.LoadScene(id);
    }
}
