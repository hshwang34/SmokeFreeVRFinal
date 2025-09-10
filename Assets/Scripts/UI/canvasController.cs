using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasController : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject beginSessionButton;

    public void displayBeginSession()
    {
        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }

        if (beginSessionButton != null)
        {
            beginSessionButton.SetActive(true);
        }
    }
}
