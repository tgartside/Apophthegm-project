using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour
{
    public RectTransform textBox;
    public TextMeshProUGUI activeTextInBox;
    public TextMeshProUGUI activeSourceText;
    public GameObject textBoxGroup;
    public BooleanValue changeSceneAfterFade;

    public void ChangeTextInBox(string newText, string newSourceText)
    {
        activeTextInBox.text = newText;
        activeSourceText.text = newSourceText;
    }

    public void CloseTextBox()
    {
        textBoxGroup.SetActive(false);
        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().name.Equals("BigRedButton"))
        {
            changeSceneAfterFade.value = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
        }
    }

    public void DisplayText(string textToDisplay, string sourceToDisplay)
    {
        if (!SceneManager.GetActiveScene().name.Equals("BigRedButton"))
        {
            Time.timeScale = 0f;
        }
        ChangeTextInBox(textToDisplay, sourceToDisplay);
        textBoxGroup.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
