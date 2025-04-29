using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactableObject : CollidableObject
{
    [SerializeField]
    public string levelName;
    public Vector2 playerPosition;
    public BooleanValue doFadeOut;
    public BooleanValue changeSceneAfterFade;
    //public CameraFade c_Fade;
    //public VectorValue playerStorage;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("collided tag " + this.tag);
            OnInteract();
        }
    }

    private void OnInteract()
    {
        if (this.tag == "Scene Changer")
        {
            logic.LoadScene(levelName, playerPosition);
        }

        else if(this.tag == "Exit")
        {
            changeSceneAfterFade.value = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
        }

    }
}
