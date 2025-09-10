using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToOriginalPosScript : MonoBehaviour
{
    [SerializeField] private GameObject cigarette;
    [SerializeField] private GameObject lighter;
    [SerializeField] private GameObject ashtray;
    [SerializeField] private GameObject cigPack;

    [SerializeField] private Transform cigaretteReturnPosition;
    [SerializeField] private Transform lighterReturnPosition;
    [SerializeField] private Transform ashtrayReturnPosition;
    [SerializeField] private Transform cigPackReturnPosition;

    private Quaternion _cigaretteInitialRotation;
    private Quaternion _lighterInitialRotation;
    private Quaternion _ashtrayInitialRotation;
    private Quaternion _cigPackInitialRotation;

    private const float YOffset = 0.3f;

    private void Start()
    {
        CacheInitialRotations();
    }

    private void CacheInitialRotations()
    {
        if (cigarette != null)
        {
            _cigaretteInitialRotation = cigarette.transform.rotation;
        }
        if (lighter != null)
        {
            _lighterInitialRotation = lighter.transform.rotation;
        }
        if (ashtray != null)
        {
            _ashtrayInitialRotation = ashtray.transform.rotation;
        }
        if (cigPack != null)
        {
            _cigPackInitialRotation = cigPack.transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        
        if (other.transform.IsChildOf(cigarette.transform))
        {
            ResetObjectPosition(cigarette, cigaretteReturnPosition, _cigaretteInitialRotation);
        }
        else if (other.transform.IsChildOf(lighter.transform))
        {
            ResetObjectPosition(lighter, lighterReturnPosition, _lighterInitialRotation);
        }
        else if (other.transform.IsChildOf(ashtray.transform))
        {
            ResetObjectPosition(ashtray, ashtrayReturnPosition, _ashtrayInitialRotation);
        }
        else if (other.transform.IsChildOf(cigPack.transform))
        {
            ResetObjectPosition(cigPack, cigPackReturnPosition, _cigPackInitialRotation);
        }
    }

    private void ResetObjectPosition(GameObject obj, Transform returnPosition, Quaternion initialRotation)
    {
        if (obj == null || returnPosition == null) return;

        Vector3 adjustedPosition = returnPosition.position + new Vector3(0, YOffset, 0);
        obj.transform.position = adjustedPosition;
        obj.transform.rotation = initialRotation;

        if (obj.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
