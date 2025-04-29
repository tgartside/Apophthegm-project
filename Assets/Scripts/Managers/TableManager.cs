using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableManager : MonoBehaviour
{
    public string sceneToLoad;
    public string currentScene;
    public Vector2 playerPosition;
    public LogicScript logic;

    [Header("Game Objects")]
    public GameObject book;
    public GameObject pin;
    public GameObject pen;
    public GameObject drawer;

    [Header("Scriptable Objects")]
    public BooleanValue bookPickedUp;
    public BooleanValue pinPickedUp;
    public BooleanValue penPickedUp;
    public BooleanValue drawerOpen;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (currentScene.Equals("R1Table"))
        {
            if (bookPickedUp.value == true)
            {
                book.SetActive(false);
            }
            if (drawerOpen.value == true)
            {
                drawer.SetActive(true);
            }
        }
      
        else if (currentScene.Equals("Drawer"))
        {
            if (pinPickedUp.value == true)
            {
                pin.SetActive(false);
            }
            if (penPickedUp.value == true)
            {
                pen.SetActive(false);
            }
        }

        DontDestroyOnLoad(this);
    }

    public void Exit()
    {
        logic.LoadScene(sceneToLoad, playerPosition);
    }
}
