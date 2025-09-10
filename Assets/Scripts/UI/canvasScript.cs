using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canvasScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private List<string> presetTexts;
    
    private int _currentTextIndex = 0;

    private void Start()
    {
        ShowNextText();
    }

    private void Update()
    {
        if (playerTransform == null) return;

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.y = 0;
        directionToPlayer = -directionToPlayer;
        transform.forward = directionToPlayer;
    }

    public void ShowNextText()
    {
        if (!HasValidTextComponents()) return;
        if (!HasValidTextIndex()) return;

        tmpText.text = presetTexts[_currentTextIndex];
        _currentTextIndex++;
    }

    private bool HasValidTextComponents()
    {
        return tmpText != null && presetTexts != null && presetTexts.Count > 0;
    }

    private bool HasValidTextIndex()
    {
        return _currentTextIndex < presetTexts.Count;
    }
}
