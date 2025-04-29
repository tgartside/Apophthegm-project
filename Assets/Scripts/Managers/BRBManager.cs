using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRBManager : MonoBehaviour
{
    public BooleanValue changeSceneAfterFade;
    public void goToEnd()
    {
        Time.timeScale = 1.0f;
        changeSceneAfterFade.value = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().StartFadeOut();
    }
}
