using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    private int _currentClipIndex = 0;

    private void Start()
    {
        InitializeAudioSource();
        PlayCurrentClip();
    }

    private void InitializeAudioSource()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource == null)
        {
            Debug.LogError(nameof(AudioSource) + " component not found on " + nameof(AudioPlayerController) + "!");
            enabled = false;
        }
    }

    public void PlayCurrentClip()
    {
        if (!HasValidAudioClips()) return;

        audioSource.clip = audioClips[_currentClipIndex];
        audioSource.Play();
    }

    public void PlayNextClip()
    {
        if (!HasValidAudioClips()) return;

        _currentClipIndex = (_currentClipIndex + 1) % audioClips.Count;
        PlayCurrentClip();
    }

    public void PlayPreviousClip()
    {
        if (!HasValidAudioClips()) return;

        _currentClipIndex = ((_currentClipIndex - 1) + audioClips.Count) % audioClips.Count;
        PlayCurrentClip();
    }

    private bool HasValidAudioClips()
    {
        return audioClips != null && audioClips.Count > 0;
    }
}
