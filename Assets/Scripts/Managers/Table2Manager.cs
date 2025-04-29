using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Table2Manager : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public LogicScript logic;

    [Header("Game Objects")]
    public GameObject book;

    [Header("Scriptable Objects")]
    public BooleanValue book2PickedUp;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (book2PickedUp.value == true)
        {
            book.SetActive(false);
        }

        DontDestroyOnLoad(this);
    }

    public void Exit()
    {
        logic.LoadScene(sceneToLoad, playerPosition);
    }
}
