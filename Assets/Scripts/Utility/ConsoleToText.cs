using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConsoleToText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;
    
    private string _output = "";
    private string _stack = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
        Debug.Log("Log Enabled");
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
        ClearLog();
    }

    public void ClearLog()
    {
        _output = "";
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        _output = logString + "\n" + _output;
        _stack = stackTrace;
    }

    private void OnGUI()
    {
        if (debugText != null)
        {
            debugText.text = _output;
        }
    }
}
