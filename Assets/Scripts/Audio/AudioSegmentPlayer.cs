using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSegmentPlayer : MonoBehaviour
{
    [Tooltip("Start time in seconds.")]
    [SerializeField] private float segmentStartTime = 10f;

    [Tooltip("Duration of the segment to play in seconds.")]
    [SerializeField] private float segmentDuration = 5f;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource == null)
        {
            Debug.LogError(nameof(AudioSource) + " component not found on " + nameof(AudioSegmentPlayer) + "!");
            enabled = false;
        }
    }

    public void PlaySegment()
    {
        if (!HasValidAudioClip()) return;

        _audioSource.time = segmentStartTime;
        _audioSource.Play();
        Invoke(nameof(StopPlaying), segmentDuration);
    }

    private bool HasValidAudioClip()
    {
        return _audioSource != null && _audioSource.clip != null;
    }

    private void StopPlaying()
    {
        if (_audioSource != null)
        {
            _audioSource.Stop();
        }
    }
}
