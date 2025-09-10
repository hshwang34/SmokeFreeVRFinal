using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lungSceneController : MonoBehaviour
{
    [SerializeField] private GameObject EndCanvas;
    [SerializeField] private GameObject IntroCanvas;
    
    private void Start()
    {
        DisplayIntroCanvas();
    }

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

    private void DisplayIntroCanvas()
    {
        SetCanvasState(IntroCanvas, true);
        SetCanvasState(EndCanvas, false);
    }

    public void HideIntroCanvas()
    {
        SetCanvasState(IntroCanvas, false);
        SetCanvasState(EndCanvas, false);
    }

    public void DisplayEndCanvas()
    {
        SetCanvasState(EndCanvas, true);
        SetCanvasState(IntroCanvas, false);
    }

    private void SetCanvasState(GameObject canvas, bool active)
    {
        if (canvas != null)
        {
            canvas.SetActive(active);
        }
    }
}
