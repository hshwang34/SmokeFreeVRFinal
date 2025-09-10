using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    [SerializeField] private GameObject canvasCCObject;
    [SerializeField] private float delayBeforeRemyWalks = 10.0f;
    [SerializeField] private GameObject endCanvas;

    private Animator _animator;
    private int _currentAnimationStates = 0;
    private readonly string[] _animationBooleans = 
    {
        "1st Interaction",
        "2nd Interaction", 
        "3rd Interaction",
        "4th Interaction",
        "5th Interaction",
        "6th Interaction",
        "7th Interaction",
        "End Interaction"
    };
    private canvasScript _canvasScript;
    private avatarAudioScript _audioScript;
    private WaitForSeconds _waitForDelay;
    private WaitForSeconds _waitForEndDelay;

    private const float EndDelay = 5.0f;
    private const string AnimationStartBool = "AnimationStart";
    private const string ReachedPlayerBool = "reachedPlayer";
    private const string EndInteractionString = "End Interaction";

    private void Awake()
    {
        _waitForDelay = new WaitForSeconds(delayBeforeRemyWalks);
        _waitForEndDelay = new WaitForSeconds(EndDelay);
    }

    private void Start()
    {
        if (!InitializeComponents())
        {
            enabled = false;
            return;
        }
    }

    private bool InitializeComponents()
    {
        _audioScript = GetComponent<avatarAudioScript>();
        _animator = GetComponent<Animator>();
        
        if (canvasCCObject == null)
        {
            Debug.LogError(nameof(canvasCCObject) + " reference not set in " + nameof(animationStateController) + "!");
            return false;
        }
        
        _canvasScript = canvasCCObject.GetComponent<canvasScript>();
        return true;
    }

    public void startAnimationSession()
    {
        StartCoroutine(StartAnimationAfterDelay());
    }

    private IEnumerator StartAnimationAfterDelay()
    {
        yield return _waitForDelay;
        
        if (_animator != null)
        {
            _animator.SetBool(AnimationStartBool, true);
        }
    }

    public void respondToInteractionPlayAudio()
    {
        if (CanProcessInteraction())
        {
            ProcessAnimationState();
        }
        
        if (_canvasScript != null)
        {
            _canvasScript.ShowNextText();
        }
    }

    private bool CanProcessInteraction()
    {
        return _animator != null 
            && _animator.GetBool(AnimationStartBool) 
            && _animator.GetBool(ReachedPlayerBool);
    }

    private void ProcessAnimationState()
    {
        if (_currentAnimationStates < _animationBooleans.Length)
        {
            _animator.SetBool(_animationBooleans[_currentAnimationStates], true);
            
            if (_audioScript != null)
            {
                _audioScript.PlayNextAudioClip();
            }

            if (_animationBooleans[_currentAnimationStates] == EndInteractionString)
            {
                StartCoroutine(ActivateObjectAfterDelay());
            }
        }
        _currentAnimationStates++;
    }

    private IEnumerator ActivateObjectAfterDelay()
    {
        yield return _waitForEndDelay;
        
        if (endCanvas != null)
        {
            endCanvas.SetActive(true);
        }
        
        if (canvasCCObject != null)
        {
            canvasCCObject.SetActive(false);
        }
    }
}
