using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthColliderScript : MonoBehaviour
{
    [SerializeField] private AudioSource breathingAudioSource;
    [SerializeField] private ParticleSystem smokeParticle;

    private const string CigaretteTag = "Cigarette";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CigaretteTag))
        {
            PlaySmokeEffects();
        }
    }

    private void PlaySmokeEffects()
    {
        if (breathingAudioSource != null)
        {
            breathingAudioSource.Play();
        }

        if (smokeParticle != null)
        {
            smokeParticle.Play();
        }
    }
}
