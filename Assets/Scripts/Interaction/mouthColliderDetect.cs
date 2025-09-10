using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthColliderDetect : MonoBehaviour
{
    [SerializeField] private ParticleSystem smokeLungParticle;
    [SerializeField] private Animator lungAnimator;
    [SerializeField] private float smokeDelay = 2.20f;
    [SerializeField] private AudioSource breathingAudioSource;
    [SerializeField] private AudioSource lungAudioSource;
    [SerializeField] private LungColorChange lungColorChange;

    private const string LungAnimationName = "Full_High";
    private const int MaxSmokeCount = 5;
    private const float BreathingAudioDelay = 0.5f;
    
    private int _smokeCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Cigarette")) return;

        if (_smokeCounter < MaxSmokeCount)
        {
            ProcessSmokeInteraction();
        }
        else
        {
            StopLungAnimation();
        }
    }

    private void ProcessSmokeInteraction()
    {
        _smokeCounter++;
        PlayLungAnimation();
        PlayAudioEffects();
        Invoke(nameof(StartSmokeParticle), smokeDelay);
    }

    private void PlayLungAnimation()
    {
        if (lungAnimator != null)
        {
            lungAnimator.Play(LungAnimationName);
        }
    }

    private void PlayAudioEffects()
    {
        breathingAudioSource.PlayDelayed(BreathingAudioDelay);
        lungAudioSource.Play();
    }

    private void StopLungAnimation()
    {
        if (lungAnimator != null)
        {
            lungAnimator.speed = 0;
        }
    }

    private void StartSmokeParticle()
    {
        if (smokeLungParticle != null)
        {
            smokeLungParticle.Play();
        }
        
        if (lungColorChange != null)
        {
            lungColorChange.OnSmoke();
        }
    }
}
