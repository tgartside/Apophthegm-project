using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public LogicScript logic;
    public Vector2 playerPosition;
    public void changeScene()
    {
        logic.LoadScene("Room1", playerPosition);
    }
}
