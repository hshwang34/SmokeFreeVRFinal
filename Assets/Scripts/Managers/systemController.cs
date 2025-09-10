using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class systemController : MonoBehaviour
{
    public static bool hasSeenIntro = false;
    
    [SerializeField] private DemoScript demoScriptReference;
    [SerializeField] private GameObject warningCanvas;
    [SerializeField] private GameObject introCanvas;
    [SerializeField] private GameObject deskMenuItems;
    [SerializeField] private GameObject desk;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject smokingScene;
    [SerializeField] private smokingSceneController smokingSceneController;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float transitionSpeed = 1.0f;

    private WaitForSeconds _waitForTransition;

    private const float SettingsCanvasDelay = 1.0f;

    private void Awake()
    {
        _waitForTransition = new WaitForSeconds(1f / transitionSpeed);
    }

    private void Start()
    {
        if (!InitializeDemoScript())
        {
            enabled = false;
            return;
        }

        InitializeDemoEnvironment();
        InitializeSceneState();
    }

    private bool InitializeDemoScript()
    {
        if (demoScriptReference == null)
        {
            Debug.LogError(nameof(DemoScript) + " reference not set in " + nameof(systemController) + "!");
            return false;
        }
        return true;
    }

    private void InitializeDemoEnvironment()
    {
        demoScriptReference.NextLand();
        demoScriptReference.NextSky();
    }

    private void InitializeSceneState()
    {
        if (hasSeenIntro)
        {
            ShowHomeSceneRevisited();
        }
        else
        {
            ShowInitialWarning();
        }
    }

    private void ShowInitialWarning()
    {
        SetCanvasState(warningCanvas, true);
        SetCanvasState(desk, true);
        SetCanvasState(introCanvas, false);
        SetCanvasState(settingsCanvas, false);
        SetCanvasState(deskMenuItems, false);
    }

    private void ShowHomeSceneRevisited()
    {
        SetCanvasState(warningCanvas, false);
        SetCanvasState(introCanvas, false);
        SetCanvasState(settingsCanvas, false);
        SetCanvasState(desk, true);
        SetCanvasState(deskMenuItems, true);
    }

    private void SetCanvasState(GameObject canvas, bool active)
    {
        if (canvas != null)
        {
            canvas.SetActive(active);
        }
    }

    public void hideWarningCanvas()
    {
        SetCanvasState(warningCanvas, false);
        SetCanvasState(introCanvas, true);
        SetCanvasState(deskMenuItems, false);
        hasSeenIntro = true;
    }

    public void hideIntroCanvas()
    {
        SetCanvasState(warningCanvas, false);
        StartCoroutine(SwitchMenus(deskMenuItems, introCanvas));
    }

    public void openSmokingScene()
    {
        SetCanvasState(warningCanvas, false);
        SetCanvasState(introCanvas, false);
        SetCanvasState(deskMenuItems, false);

        StartCoroutine(SwitchMenus(smokingScene, deskMenuItems));
        StartCoroutine(ActivateSettingsCanvasAfterDelay(SettingsCanvasDelay));
    }

    private IEnumerator ActivateSettingsCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetCanvasState(settingsCanvas, true);
    }

    public void returnToMainMenuFromSmokingScene()
    {
        SetCanvasState(settingsCanvas, false);
        StartCoroutine(SwitchMenus(deskMenuItems, smokingScene));
    }

    public void toggleSettingCanvas()
    {
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(!settingsCanvas.activeSelf);
        }
    }

    private IEnumerator SwitchMenus(GameObject toActivate, GameObject toDeactivate)
    {
        FadeOutScreen();
        yield return _waitForTransition;
        SetCanvasState(toDeactivate, false);
        SetCanvasState(toActivate, true);
        FadeInScreen();
    }

    private void FadeInScreen()
    {
        StartCoroutine(FadeIn());
    }

    private void FadeOutScreen()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        if (fadeImage == null) yield break;

        float alpha = fadeImage.color.a;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * transitionSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        if (fadeImage == null) yield break;

        float alpha = fadeImage.color.a;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * transitionSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}

