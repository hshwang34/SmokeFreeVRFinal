using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator _animator;
    private bool _isPaused = false;

    private const float PausedSpeed = 0f;
    private const float NormalSpeed = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        if (_animator == null)
        {
            Debug.LogError(nameof(Animator) + " component not found on " + nameof(AnimationControl) + "!");
            enabled = false;
        }
    }

    public void ToggleAnimation()
    {
        if (_isPaused)
        {
            PlayAnimation();
        }
        else
        {
            PauseAnimation();
        }
    }

    private void PauseAnimation()
    {
        if (_animator != null)
        {
            _animator.speed = PausedSpeed;
            _isPaused = true;
        }
    }

    private void PlayAnimation()
    {
        if (_animator != null)
        {
            _animator.speed = NormalSpeed;
            _isPaused = false;
        }
    }
}
