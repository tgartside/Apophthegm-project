using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreenManager : MonoBehaviour
{
    public BooleanValue gameWon;
    public TMP_Text titleText;
    public GameObject developerText;
    public Text startButtonText;

    private void Start()
    {
        if (gameWon.value == true)
        {
            developerText.SetActive(false);
            titleText.text = "You Win!";
            startButtonText.GetComponent<Text>().text = "Play Again";
        }
    }
}
