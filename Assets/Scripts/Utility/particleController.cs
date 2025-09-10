using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleToPlay;

    public void PlayParticles()
    {
        if (!ValidateParticleSystem()) return;
        particleToPlay.Play();
    }

    public void StopParticles()
    {
        if (!ValidateParticleSystem()) return;
        particleToPlay.Stop();
    }

    public void StopAndClearParticles()
    {
        if (!ValidateParticleSystem()) return;
        
        particleToPlay.Stop();
        particleToPlay.Clear();
    }

    private bool ValidateParticleSystem()
    {
        if (particleToPlay == null)
        {
            Debug.LogWarning(nameof(ParticleSystem) + " reference is missing in " + nameof(particleController) + "!");
            return false;
        }
        return true;
    }
}
