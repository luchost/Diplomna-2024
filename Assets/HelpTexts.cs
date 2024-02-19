using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTexts : MonoBehaviour
{
    public HashSet<int> displayedHelpIds;

    // store this in a singleton to be globally accessible
    private static HelpTexts _instance = null;
    public static HelpTexts Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        transform.parent = null;
        displayedHelpIds = new HashSet<int>();
        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

}
