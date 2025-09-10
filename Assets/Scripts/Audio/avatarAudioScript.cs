using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class avatarAudioScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    
    private int _currentClipIndex = 0;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource == null)
        {
            Debug.LogError(nameof(AudioSource) + " component not found on " + nameof(avatarAudioScript) + "!");
            enabled = false;
        }
    }

    public void PlayNextAudioClip()
    {
        if (_audioSource.isPlaying) return;
        if (!HasValidAudioClips()) return;

        PlayCurrentClip();
        _currentClipIndex++;
    }

    private bool HasValidAudioClips()
    {
        return audioClips != null && _currentClipIndex < audioClips.Length;
    }

    private void PlayCurrentClip()
    {
        _audioSource.clip = audioClips[_currentClipIndex];
        _audioSource.Play();
    }
}
