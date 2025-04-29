using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    
    //public bool canMove;
    public bool canOpenInv;
    public GameObject inventoryScreen;
    public GameObject[] objs;
    public Sprite openDoorSprite;
    public Sprite closedDoorSprite;
    public Sprite rippedPaintingSprite;
    public GameObject closedBookcase;
    public GameObject openBookcase;
    public GameObject exitDoor;
    public GameObject pauseMenu;

    [Header("Scriptable Objects")]
    public VectorValue playerStorage;
    public IntegerValue rotationCount;
    public BooleanValue bookPickedUp;
    public BooleanValue keyPickedUp;
    public BooleanValue pinPickedUp;
    public BooleanValue penPickedUp;
    public BooleanValue drawerOpen;
    public BooleanValue R1DoorOpen;
    public BooleanValue bookcaseOpen;
    public BooleanValue book2PickedUp;
    public BooleanValue paintingRipped;
    public BooleanValue finalNoteRead;
    public BooleanValue doFadeOut;
    public BooleanValue deathButtonPressed;
    public BooleanValue changeSceneAfterFade;
    public BooleanValue gameWon;
    public BooleanValue startingGame;
    public BooleanValue gamePaused;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Room1"))
        {
            if(startingGame.value == true)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().startFadedOut = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeIn();
                startingGame.value = false;
            }
            

            GameObject R1Door = GameObject.Find("R1Door");
            if (R1DoorOpen.value == true)
            {
                R1Door.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
                R1Door.GetComponent<interactableObject>().levelName = "Room2";
            }
            else
            {
                R1Door.GetComponent<SpriteRenderer>().sprite = closedDoorSprite;
                R1Door.GetComponent<interactableObject>().levelName = "Door";
            }

            if(finalNoteRead.value == true)
            {
                exitDoor.SetActive(true);
            }
        }

        if (SceneManager.GetActiveScene().name.Equals("Room2"))
        {

            GameObject painting = GameObject.Find("Painting");
            if (bookcaseOpen.value == true)
            {
                closedBookcase.SetActive(false);
                openBookcase.SetActive(true);
                DontDestroyOnLoad(this);
            }

            if(paintingRipped.value == true)
            {
                painting.GetComponent<SpriteRenderer>().sprite = rippedPaintingSprite;
            }
        }
    }

    public void StartGame(string levelName)
    {
        bookPickedUp.value = false;
        keyPickedUp.value = false;
        pinPickedUp.value = false;
        penPickedUp.value = false;
        drawerOpen.value = false;
        R1DoorOpen.value = false;
        book2PickedUp.value = false;
        bookcaseOpen.value = false;
        paintingRipped.value = false;
        doFadeOut.value = false;
        deathButtonPressed.value = false;
        finalNoteRead.value = false;
        changeSceneAfterFade.value = false;
        gameWon.value = false;
        startingGame.value = true;
        gamePaused.value = false;


        playerStorage.initialValue.Set(0, -3.8f);
        rotationCount.initialValue = 0;
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string levelName, Vector2 playerPosition)
    {
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene(levelName);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Unpause();
            }

            else
            {
                gamePaused.value = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;

                objs = GameObject.FindGameObjectsWithTag("Button");
                foreach (GameObject button in objs)
                {
                    button.GetComponent<Button>().interactable = false;
                }
            }
        }

        if (gamePaused.value == false)
        {
            if (canOpenInv)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    if (inventoryScreen.activeSelf)
                    {
                        PlayerPrefs.SetInt("usingItem", 0);
                        inventoryScreen.SetActive(false);
                        Time.timeScale = 1.0f;

                        objs = GameObject.FindGameObjectsWithTag("Button");
                        foreach (GameObject button in objs)
                        {
                            button.GetComponent<Button>().interactable = true;
                        }
                    }

                    else
                    {
                        inventoryScreen.SetActive(true);
                        Time.timeScale = 0f;

                        objs = GameObject.FindGameObjectsWithTag("Button");
                        foreach (GameObject button in objs)
                        {
                            button.GetComponent<Button>().interactable = false;
                        }
                    }
                }
            }
        }
    }

    public void Unpause()
    {
        gamePaused.value = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

        objs = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in objs)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }

    public void returnToTitle()
    {
        gamePaused.value = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScreen");
    }
}
