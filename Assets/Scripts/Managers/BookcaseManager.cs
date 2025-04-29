using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookcaseManager : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public LogicScript logic;

    public void Exit()
    {
        logic.LoadScene(sceneToLoad, playerPosition);
    }
}
