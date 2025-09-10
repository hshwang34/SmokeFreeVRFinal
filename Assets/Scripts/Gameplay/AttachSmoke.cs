using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSmoke : MonoBehaviour
{
    [SerializeField] private Transform cigaretteTip;
    [SerializeField] private ParticleSystem smokeParticle;

    private void Update()
    {
        if (!HasValidComponents()) return;

        UpdateSmokePosition();
    }

    private bool HasValidComponents()
    {
        return cigaretteTip != null && smokeParticle != null;
    }

    private void UpdateSmokePosition()
    {
        smokeParticle.transform.position = cigaretteTip.position;
        smokeParticle.transform.rotation = Quaternion.identity;
    }
}
