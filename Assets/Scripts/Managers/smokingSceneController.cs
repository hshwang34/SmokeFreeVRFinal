using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokingSceneController : MonoBehaviour
{
    [SerializeField] private GameObject cigarette;
    [SerializeField] private GameObject lighter;
    [SerializeField] private GameObject ashtray;
    [SerializeField] private GameObject cigPack;
    [SerializeField] private GameObject ash;
    [SerializeField] private ParticleSystem particleSystems;

    private Vector3 _cigaretteInitialPosition;
    private Quaternion _cigaretteInitialRotation;
    private Vector3 _lighterInitialPosition;
    private Quaternion _lighterInitialRotation;
    private Vector3 _ashtrayInitialPosition;
    private Quaternion _ashtrayInitialRotation;
    private Vector3 _cigPackInitialPosition;
    private Quaternion _cigPackInitialRotation;
    private Vector3 _ashInitialPosition;
    private Quaternion _ashInitialRotation;

    private void Start()
    {
        if (!ValidateRequiredObjects())
        {
            enabled = false;
            return;
        }

        CacheInitialTransforms();
    }

    private bool ValidateRequiredObjects()
    {
        if (cigarette == null || lighter == null || ashtray == null || cigPack == null || ash == null)
        {
            Debug.LogError("One or more required GameObjects are not assigned in " + nameof(smokingSceneController) + "!");
            return false;
        }
        return true;
    }

    private void CacheInitialTransforms()
    {
        _cigaretteInitialPosition = cigarette.transform.position;
        _cigaretteInitialRotation = cigarette.transform.rotation;
        _lighterInitialPosition = lighter.transform.position;
        _lighterInitialRotation = lighter.transform.rotation;
        _ashtrayInitialPosition = ashtray.transform.position;
        _ashtrayInitialRotation = ashtray.transform.rotation;
        _cigPackInitialPosition = cigPack.transform.position;
        _cigPackInitialRotation = cigPack.transform.rotation;
        _ashInitialPosition = ash.transform.position;
        _ashInitialRotation = ash.transform.rotation;
    }

    public void resetScene()
    {
        PauseParticleSystems();
        ResetAllObjects();
    }

    private void PauseParticleSystems()
    {
        if (particleSystems != null)
        {
            particleSystems.Pause();
        }
    }

    private void ResetAllObjects()
    {
        ResetObject(cigarette, _cigaretteInitialPosition, _cigaretteInitialRotation);
        ResetObject(lighter, _lighterInitialPosition, _lighterInitialRotation);
        ResetObject(ashtray, _ashtrayInitialPosition, _ashtrayInitialRotation);
        ResetObject(cigPack, _cigPackInitialPosition, _cigPackInitialRotation);
        ResetObject(ash, _ashInitialPosition, _ashInitialRotation);
    }

    private void ResetObject(GameObject obj, Vector3 position, Quaternion rotation)
    {
        if (obj == null) return;

        obj.transform.position = position;
        obj.transform.rotation = rotation;

        if (obj.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
