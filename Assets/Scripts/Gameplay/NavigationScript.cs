using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform lookAtTarget;
    [SerializeField] private GameObject canvasCCObject;
    [SerializeField] private Transform nextDestination;

    private NavMeshAgent _agent;
    private Animator _animator;
    private avatarAudioScript _audioScript;
    private bool _hasReachedDestination = false;
    private const float RotationSpeed = 5f;
    private const float VelocityThreshold = 0.1f;

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioScript = GetComponent<avatarAudioScript>();

        if (_agent == null || _animator == null)
        {
            Debug.LogError("Required components not found on " + nameof(NavigationScript) + "!");
            enabled = false;
        }
    }

    private void Update()
    {
        if (_hasReachedDestination)
        {
            HandleDestinationReached();
        }
        else
        {
            HandleNavigationToPlayer();
        }
    }

    private void HandleDestinationReached()
    {
        if (!_animator.GetBool("End Interaction"))
        {
            LookAtTargetYOnly(lookAtTarget);
        }
        else
        {
            MoveToNextDestination();
        }
    }

    private void MoveToNextDestination()
    {
        if (nextDestination == null) return;

        _agent.destination = nextDestination.position;
        LookAtTargetYOnly(nextDestination);
        _agent.isStopped = false;
        _agent.SetDestination(nextDestination.position);
        Debug.Log("Trying to set agent destination to nextDestination");
    }

    private void HandleNavigationToPlayer()
    {
        if (!_animator.GetBool("AnimationStart")) return;
        if (player == null) return;

        _agent.destination = player.position;

        if (HasReachedPlayer())
        {
            OnReachedPlayer();
        }
    }

    private bool HasReachedPlayer()
    {
        return !_agent.pathPending
            && _agent.remainingDistance <= _agent.stoppingDistance
            && _agent.velocity.sqrMagnitude < VelocityThreshold;
    }

    private void OnReachedPlayer()
    {
        _hasReachedDestination = true;
        _animator.SetBool("reachedPlayer", true);
        
        if (canvasCCObject != null)
        {
            canvasCCObject.SetActive(true);
        }
        
        if (_audioScript != null)
        {
            _audioScript.PlayNextAudioClip();
        }
    }

    private void LookAtTargetYOnly(Transform target)
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
    }
}
