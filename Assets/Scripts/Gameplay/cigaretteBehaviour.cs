using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cigaretteBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject smokeParticle;
    [SerializeField] private GameObject lighter;
    [SerializeField] private AudioSource cigPutOutAudioSource;

    private MeshCollider _meshCollider;
    private ParticleSystem _smokeParticleSystem;
    private WaitForSeconds _waitForLightDelay;

    private const string AshtrayTag = "Ashtray";
    private const float LightDelay = 5f;

    private void Awake()
    {
        _waitForLightDelay = new WaitForSeconds(LightDelay);
    }

    private void Start()
    {
        if (!InitializeComponents())
        {
            enabled = false;
            return;
        }

        InitializeParticleSystem();
    }

    private bool InitializeComponents()
    {
        _meshCollider = GetComponent<MeshCollider>();
        if (_meshCollider == null)
        {
            Debug.LogWarning(nameof(MeshCollider) + " not found on cigarette object!");
        }

        if (smokeParticle == null)
        {
            Debug.LogError(nameof(smokeParticle) + " reference not set in " + nameof(cigaretteBehaviour) + "!");
            return false;
        }

        _smokeParticleSystem = smokeParticle.GetComponent<ParticleSystem>();
        return true;
    }

    private void InitializeParticleSystem()
    {
        smokeParticle.SetActive(false);
        _smokeParticleSystem.Pause();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == lighter)
        {
            LightCigarette();
        }

        if (collision.gameObject.CompareTag(AshtrayTag))
        {
            ExtinguishCigarette();
        }
    }

    public void LightCigarette()
    {
        StartCoroutine(DelayedLightCigarette());
    }

    private IEnumerator DelayedLightCigarette()
    {
        yield return _waitForLightDelay;
        
        if (smokeParticle != null)
        {
            smokeParticle.SetActive(true);
        }
        
        if (_smokeParticleSystem != null)
        {
            _smokeParticleSystem.Play();
        }
        
        Debug.Log("Cigarette is lit!");
    }

    public void ExtinguishCigarette()
    {
        if (smokeParticle != null)
        {
            smokeParticle.SetActive(false);
        }
        
        if (_smokeParticleSystem != null)
        {
            _smokeParticleSystem.Pause();
        }
        
        if (cigPutOutAudioSource != null)
        {
            cigPutOutAudioSource.Play();
        }
    }
}
