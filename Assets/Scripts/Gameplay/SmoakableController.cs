using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SmokableController : MonoBehaviour
{
    [Header("Models")]
    [SerializeField] private GameObject defaultModel;
    [SerializeField] private GameObject litModel;
    
    [Header("Particle System")]
    [SerializeField] private ParticleSystem smokeParticleSystem;

    [Header("Interaction Tags")]
    [SerializeField] private string lighterTag = "LighterCollider";
    [SerializeField] private string ashtrayTag = "AshtrayCollider";

    public bool IsSmokableLit { get; private set; } = false;

    private void Start()
    {
        if (!ValidateRequiredComponents())
        {
            enabled = false;
            return;
        }

        InitializeParticleSystem();
    }

    private bool ValidateRequiredComponents()
    {
        if (defaultModel == null || litModel == null)
        {
            Debug.LogError("Models are not assigned in " + nameof(SmokableController) + "!");
            return false;
        }

        if (smokeParticleSystem == null)
        {
            Debug.LogError("Particle System is missing in " + nameof(SmokableController) + "!");
            return false;
        }

        return true;
    }

    private void InitializeParticleSystem()
    {
        smokeParticleSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(lighterTag) && !IsSmokableLit)
        {
            LightCigar();
        }
        else if (other.CompareTag(ashtrayTag) && IsSmokableLit)
        {
            ExtinguishCigar();
        }
    }

    private void LightCigar()
    {
        if (smokeParticleSystem != null)
        {
            smokeParticleSystem.Play();
        }
        IsSmokableLit = true;
    }

    private void ExtinguishCigar()
    {
        if (smokeParticleSystem != null)
        {
            smokeParticleSystem.Stop();
        }
        IsSmokableLit = false;
    }
}
