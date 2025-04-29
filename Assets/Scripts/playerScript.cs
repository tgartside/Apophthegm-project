using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
   // public LogicScript logic;
    public float movementSpeed = 1;
    public double leftWall = -8.5;
    public double rightWall = 8.5;
    public VectorValue startingPosition;
    public LogicScript logic;
    //public GameObject inventoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > leftWall)
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < rightWall)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
    }
}
