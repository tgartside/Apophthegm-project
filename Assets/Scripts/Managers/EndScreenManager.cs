using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public BooleanValue deathButtonPressed;
    public BooleanValue changeSceneAfterFade;
    public BooleanValue deathByClock;
    public BooleanValue gameWon;
    public BooleanValue startingGame;
    public TextBoxManager textBoxManager;
    public GameObject textBoxButton;


    private void Start()
    {
        changeSceneAfterFade.value = false;

        if(startingGame.value == true)
        {
            textBoxManager.DisplayText("“Escapism isn't good or bad of itself. " +
                                        "What is important is what you are escaping from " +
                                        "and where you are escaping to.“",
                                        "― Terry Pratchett, A Slip of the Keyboard: Collected Non-Fiction");

            textBoxButton.SetActive(true);
            Time.timeScale = 1.0f;
        }

        else if (deathButtonPressed.value == true)
        {
            textBoxManager.DisplayText("There is more to discover...", "");
            Time.timeScale = 1.0f;
        }

        else if(deathByClock.value == true)
        {
            textBoxManager.DisplayText("“Time is a drug. Too much of it kills you.”",
                                        "― Terry Pratchett, Small Gods");

            textBoxButton.SetActive(true);
            Time.timeScale = 1.0f;    
        }

        else
        {
            textBoxManager.DisplayText("“Why do you go away? So that you can come back. " +
                                        "So that you can see the place you came from with new eyes and extra colors. " +
                                        "And the people there see you differently, too. " +
                                        "Coming back to where you started is not the same as never leaving.”",
                                        "― Terry Pratchett, A Hat Full of Sky");

            gameWon.value = true;
            textBoxButton.SetActive(true);
            Time.timeScale = 1.0f;
        }

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeIn();

        if (deathButtonPressed.value == true)
        {
            StartCoroutine(closeAfterDelay());
        }


    }

    IEnumerator closeAfterDelay()
    {
        yield return new WaitForSeconds(3);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
        yield return new WaitForSeconds(3);
        Debug.Log("Closing Application");
        Application.Quit();
    }

    public void closeTextBoxButton()
    {
        if (startingGame.value == true)
        {
            StartCoroutine(startGame());
        }

        else
        {
            StartCoroutine(returnToTitle());
        }
    }

    IEnumerator returnToTitle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator startGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Room1");
    }


}
