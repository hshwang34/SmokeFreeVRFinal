using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour 
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 3.0f;

    private bool _isFading = false;

    private void Start()
    {
        if (fadeImage == null)
        {
            Debug.LogError(nameof(Image) + " reference not set in " + nameof(SceneTransition) + "!");
            enabled = false;
            return;
        }

        StartCoroutine(FadeIn());
    }

    public void FadeAndLoadScene(int index)
    {
        if (!_isFading)
        {
            StartCoroutine(FadeOutAndLoad(index));
        }
    }

    private IEnumerator FadeIn()
    {
        _isFading = true;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        _isFading = false;
    }

    private IEnumerator FadeOutAndLoad(int index)
    {
        _isFading = true;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        if (SceneController.Instance != null)
        {
            SceneController.Instance.LoadSceneByIndex(index);
        }
    }
}