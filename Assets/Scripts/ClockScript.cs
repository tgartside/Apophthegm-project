using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{

    //public GameObject rotatePoint;
    public string levelName;
    public Vector2 playerPosition;
    //public VectorValue playerStorage;
    public GameObject clockDoor;
    public GameObject key;
    public LogicScript logic;
    public GameObject[] objs;

    [Header("Scriptable Objects")]
    public IntegerValue rotations;
    public BooleanValue keyPickedUp;
    public BooleanValue deathByClock;
    public BooleanValue changeSceneAfterFade;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        if (rotations.initialValue == 5)
        {
            clockDoor.SetActive(true);
            if(keyPickedUp.value == true)
            {
                key.SetActive(false);
            }
        }
        else if (rotations.initialValue >= 8)
        {
            GameOver();
        }
    }

    public void RotateHand()
    {
        transform.Rotate(0, 0, -90);
        rotations.initialValue++;
    }

    public void Exit()
    {
        logic.LoadScene(levelName, playerPosition);
    }

    public void GoToClockFace()
    {
        rotations.initialValue = 0;
        SceneManager.LoadScene("ClockFace");
    }

    public void GameOver()
    {
        logic.canOpenInv = false;
        objs = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in objs)
        {
            button.GetComponent<Button>().interactable = false;
        }
        changeSceneAfterFade.value = true;
        deathByClock.value = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
    }

}
