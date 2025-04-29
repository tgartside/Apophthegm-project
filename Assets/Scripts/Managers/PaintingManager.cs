using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public LogicScript logic;
    public BooleanValue paintingRipped;
    public GameObject painting;
    public GameObject note;
    public Sprite rippedPaintingSprite;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (paintingRipped.value == true)
        {
            painting.GetComponent<SpriteRenderer>().sprite = rippedPaintingSprite;
            note.SetActive(true);
            painting.GetComponent<BoxCollider2D>().enabled = false;

        }

        DontDestroyOnLoad(this);
    }
    public void Exit()
    {
        logic.LoadScene(sceneToLoad, playerPosition);
    }
}
