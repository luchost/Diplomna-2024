using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpPopUps : MonoBehaviour
{
    public GameObject popUp;
    public Text title;
    public Text description;
    public float disappearTime;

    public GameObject tutorialPopUp;
    public int tutorialId;
    public Text tutorialText;
    public float tutorialDisappearTime = 0.0f;

    public void HelpSetText(int helpTextId, string titleText, string descriptionText) 
    {
        if (HelpTexts.Instance.displayedHelpIds.Contains(helpTextId))
            return;
        HelpTexts.Instance.displayedHelpIds.Add(helpTextId);

        popUp.SetActive(true);
        title.text = titleText;
        description.text = descriptionText;
        disappearTime = Time.time + 10f;
    }

    public void TutorialSetText(int _tutorialId, string text)
    {
        tutorialId = _tutorialId;
        if (text == "")
            tutorialPopUp.SetActive(false);
        else
        {
            tutorialPopUp.SetActive(true);
            tutorialText.text = text;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1")
            TutorialSetText(1, "Use WASD to move and the mouse to look around and change direction.");
    }

    void Update()
    {
        if (Time.time > disappearTime)
            popUp.SetActive(false);
    }

    // store this in a singleton to be globally accessible
    private static HelpPopUps _instance = null;
    public static HelpPopUps Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
