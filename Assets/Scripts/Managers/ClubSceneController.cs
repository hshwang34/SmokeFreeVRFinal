using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubSceneController : MonoBehaviour
{
    public void returnToMainMenu()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ReturnToMainScene();
        }
    }

    public void redoCurrentScene()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ReloadCurrentScene();
        }
    }
}
