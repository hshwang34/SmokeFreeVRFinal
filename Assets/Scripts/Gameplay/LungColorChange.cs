using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungColorChange : MonoBehaviour
{
    [SerializeField] private lungSceneController lungSceneController;
    
    [Header("Smoking Settings")]
    [Tooltip("The number of times the user has smoked.")]
    [SerializeField] private int smokeCount = 0;

    [Tooltip("The maximum number of smokes before the lungs are fully darkened.")]
    private const int MaxSmokes = 5;

    [Tooltip("The color lungs will change to after max smokes.")]
    [SerializeField] private Color maxSmokeColor = Color.black;

    [Header("Material Settings")]
    [Tooltip("The index of the material to change.")]
    [SerializeField] private int materialIndex = 0;

    private Renderer _renderer;
    private Color _originalColor;
    private Color _originalColor2;
    private Vector3 _originalLungPosition;
    private bool _isShaking = false;
    private const float ShakeMagnitude = 0.01f;
    private const float ShakeDuration = 3.0f;

    private void Start()
    {
        if (!InitializeRenderer())
        {
            enabled = false;
            return;
        }

        CacheOriginalValues();
    }

    private bool InitializeRenderer()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null || _renderer.materials.Length <= materialIndex)
        {
            Debug.LogError(nameof(Renderer) + " not found or insufficient materials in " + nameof(LungColorChange) + "!");
            return false;
        }
        return true;
    }

    private void CacheOriginalValues()
    {
        _originalColor = _renderer.materials[materialIndex].color;
        _originalColor2 = _renderer.materials[materialIndex + 1].color;
        _originalLungPosition = transform.position;
    }

    public void OnSmoke()
    {
        if (smokeCount >= MaxSmokes) return;

        smokeCount++;
        UpdateLungColor();
        Shake();
        
        if (smokeCount == MaxSmokes)
        {
            OnMaxSmokeCountReached();
        }
    }

    private void UpdateLungColor()
    {
        float smokeRatio = (float)smokeCount / MaxSmokes;
        Color newColor = Color.Lerp(_originalColor, maxSmokeColor, smokeRatio);
        Color newColor2 = Color.Lerp(_originalColor2, maxSmokeColor, smokeRatio);

        Material[] materials = _renderer.materials;
        materials[materialIndex].color = newColor;
        materials[materialIndex + 1].color = newColor2;
        _renderer.materials = materials;
    }

    private void OnMaxSmokeCountReached()
    {
        if (lungSceneController != null)
        {
            lungSceneController.DisplayEndCanvas();
        }
    }

    public void Shake()
    {
        if (!_isShaking)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        _isShaking = true;
        float elapsed = 0f;

        while (elapsed < ShakeDuration)
        {
            float xOffset = Random.Range(-ShakeMagnitude, ShakeMagnitude);
            transform.position = new Vector3(_originalLungPosition.x + xOffset, _originalLungPosition.y, _originalLungPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = _originalLungPosition;
        _isShaking = false;
    }
}





